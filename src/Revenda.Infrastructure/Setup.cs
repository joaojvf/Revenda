using Microsoft.Extensions.DependencyInjection;
using Revenda.Core.Abstractions;
using Revenda.Infrastructure.SqlServer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Revenda.Infrastructure
{
    public static class Setup
    {
        public static IServiceCollection InfraSetup(this IServiceCollection services)
        {
            services.AddScoped<IRevendaRepository, RevendaRepository>();

            return services;
        }
    }
}
