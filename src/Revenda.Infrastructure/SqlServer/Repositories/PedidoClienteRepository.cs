using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Revenda.Core.Abstractions;
using Revenda.Core.Entities;
using System.Threading;

namespace Revenda.Infrastructure.SqlServer.Repositories
{
    public class PedidoClienteRepository(ApplicationContext context) : IPedidoClienteRepository
    {
        public async Task<Guid> CreateItemPedidoAsync(PedidoCliente entity, CancellationToken cancellationToken)
        {
            context.PedidosCliente.Add(entity);
            await context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public Task<PedidoCliente?> GetPedidoClientByIdAsync(Guid revendaId, Guid productId, CancellationToken cancellationToken) => context.PedidosCliente
            .Include(r => r.Itens)
            .FirstOrDefaultAsync(x => x.RevendaId == revendaId && x.Id == productId);

    }
}
