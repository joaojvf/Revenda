using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Revenda.Core.Abstractions;
using Revenda.Core.Entities;
using System.Threading;

namespace Revenda.Infrastructure.SqlServer.Repositories
{
    public class PedidoRepository(ApplicationContext context) : IPedidoRepository
    {
        public async Task<Guid> CreatePedidoAsync(Pedido entity, CancellationToken cancellationToken)
        {
            context.Pedidos.Add(entity);
            await context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
