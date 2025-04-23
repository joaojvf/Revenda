using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using Revenda.Core.Abstractions;
using Revenda.Core.UseCases.PedidoFornecedor.CriarPedidoFornecedor;
using Revenda.Infrastructure.Gateways;
using Revenda.Infrastructure.SqlServer.Repositories;

namespace Revenda.Infrastructure
{
    public static class Setup
    {
        public static IServiceCollection InfraSetup(this IServiceCollection services)
        {
            services.AddHttpClient<IFornecedorClient, FornecedorClientMock>()
            .SetHandlerLifetime(TimeSpan.FromMinutes(5))
            .AddPolicyHandler(GetRetryPolicy())
            .AddPolicyHandler(GetCircuitBreakerPolicy());

            services.AddScoped<IRevendaRepository, RevendaRepository>();
            services.AddScoped<IItemPedidoClientRepository, ItemPedidoClienteRepository>();
            services.AddScoped<IPedidoClienteRepository, PedidoClienteRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();

            services.AddHostedService<ExecutarPedidoFornecedorJob>();

            return services;
        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                .WaitAndRetryAsync(
                    retryCount: 3,
                    sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    onRetry: (outcome, timespan, retryAttempt, context) =>
                    {
                        Console.WriteLine($"[Polly] Delaying for {timespan.TotalSeconds} seconds, then making retry {retryAttempt} for request {context.OperationKey} due to {outcome.Result?.StatusCode}");
                    });
        }

        static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(
                    handledEventsAllowedBeforeBreaking: 5,
                    durationOfBreak: TimeSpan.FromSeconds(30),
                    onBreak: (outcome, breakDelay, context) =>
                    {
                        Console.WriteLine($"[Polly] Circuit breaking for {breakDelay.TotalSeconds} seconds for request {context.OperationKey} due to {outcome.Result?.StatusCode}...");
                    },
                    onReset: (context) => Console.WriteLine($"[Polly] Circuit closed for request {context.OperationKey}. Requests flow normally."),
                    onHalfOpen: () => Console.WriteLine("[Polly] Circuit testing recovery with next request.")
                );
        }
    }
}
