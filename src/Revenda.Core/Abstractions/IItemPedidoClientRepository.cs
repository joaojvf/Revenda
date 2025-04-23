using Revenda.Core.Entities;
using Revenda.Core.UseCases.Revenda.CreateRevenda;

namespace Revenda.Core.Abstractions
{
    public interface IItemPedidoClientRepository
    {
        Task<List<ItemPedidoClienteGrouped>> GetItensPedidoClientePendentesAsync(Guid revendaId, CancellationToken cancellationToken);
    }
}
