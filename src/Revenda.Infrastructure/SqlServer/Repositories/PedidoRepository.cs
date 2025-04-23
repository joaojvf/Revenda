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

        public async Task<List<Pedido>> GetPedidosAsync(Guid revendaId, CancellationToken cancellationToken)
        {
            return await context.Pedidos
                .Include(x => x.Itens)
                .Where(x => x.RevendaId == revendaId)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Pedido>> GetPendingPedidosAsync(CancellationToken cancellationToken)
        {
            return await context.Pedidos
                .Include(x => x.Revenda)
                .Include(x => x.Itens)
                .Where(o => o.Status == StatusPedido.Pendente)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdatePedidosAsync(List<Pedido> pendingPedidos, CancellationToken cancellationToken)
        {
            context.Pedidos.UpdateRange(pendingPedidos);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
