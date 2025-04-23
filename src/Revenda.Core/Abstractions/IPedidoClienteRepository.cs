using Revenda.Core.Entities;
using Revenda.Core.UseCases.Revenda.CreateRevenda;

namespace Revenda.Core.Abstractions
{
    public interface IPedidoClienteRepository
    {
        Task<Guid> CreateItemPedidoAsync(PedidoCliente request, CancellationToken cancellationToken);
        Task<PedidoCliente?> GetPedidoClientByIdAsync(Guid revendaId, Guid productId, CancellationToken cancellationToken);
    }
}
