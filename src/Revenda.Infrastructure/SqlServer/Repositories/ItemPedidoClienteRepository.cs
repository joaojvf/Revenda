using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Revenda.Core.Abstractions;
using Revenda.Core.Entities;
using System.Linq;
using System.Threading;

namespace Revenda.Infrastructure.SqlServer.Repositories
{
    public class ItemPedidoClienteRepository(ApplicationContext context) : IItemPedidoClientRepository
    {
        public async Task<Guid> CreateItemPedidoAsync(PedidoCliente entity, CancellationToken cancellationToken)
        {
            context.PedidosCliente.Add(entity);
            await context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<List<ItemPedidoClienteGrouped>> GetItensPedidoClientePendentesAsync(Guid revendaId, CancellationToken cancellationToken)
        {
            var res = await context.ItensPedidoCliente
            .Where(ipc => ipc.PedidoCliente.RevendaId == revendaId)
                .GroupBy(ipc => ipc.ProdutoId)
                .Select(g => new ItemPedidoClienteGrouped(g.Key, g.Sum(i => i.Quantidade)))
                .ToListAsync(cancellationToken);

            return res;
        }
    }
}
