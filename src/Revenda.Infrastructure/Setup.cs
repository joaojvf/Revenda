using Microsoft.Extensions.DependencyInjection;
using Revenda.Core.Abstractions;
using Revenda.Infrastructure.SqlServer.Repositories;

namespace Revenda.Infrastructure
{
    public static class Setup
    {
        public static IServiceCollection InfraSetup(this IServiceCollection services)
        {
            services.AddScoped<IRevendaRepository, RevendaRepository>();
            services.AddScoped<IItemPedidoClientRepository, ItemPedidoClienteRepository>();
            services.AddScoped<IPedidoClienteRepository, PedidoClienteRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();

            return services;
        }
    }
}
