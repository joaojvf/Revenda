using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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
    //builder.AddSqlServerDbContext<ApplicationContext>("libraryDb");

    builder.Services.AddDbContextPool<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("libraryDb"), sqlOptions =>
    {
        // Workaround for https://github.com/dotnet/aspire/issues/1023
        sqlOptions.ExecutionStrategy(c => new RetryingSqlServerRetryingExecutionStrategy(c));
    }));
    builder.EnrichSqlServerDbContext<ApplicationContext>(settings =>
    // Disable Aspire default retries as we're using a custom execution strategy
    settings.DisableRetry = true);

    //builder.Services.AddScoped<IBookRepository, BookRepository>();
    //builder.Services.AddScoped<IReadModelBookRepository, ReadModelBookRepository>();
    //builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
    //builder.Services.AddScoped<IStoredEventsRepository, StoredEventsRepository>();
    //builder.Services.SetupInfraByAssembly();
}