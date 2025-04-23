using Microsoft.EntityFrameworkCore;
using Revenda.Core;
using Revenda.Infrastructure;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve); ;
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

SetupInfrastructure();
builder.Services.CoreSetup();
builder.Services.InfraSetup();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapScalarApiReference(options =>
{
    options.Servers = [];
});

app.Run();


void SetupInfrastructure()
{
    builder.Services.AddDbContextPool<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("revendaDb"), sqlOptions =>
    {
        // Workaround for https://github.com/dotnet/aspire/issues/1023
        sqlOptions.ExecutionStrategy(c => new RetryingSqlServerRetryingExecutionStrategy(c));
    }));
    builder.EnrichSqlServerDbContext<ApplicationContext>(settings =>
    // Disable Aspire default retries as we're using a custom execution strategy
    settings.DisableRetry = true);
}