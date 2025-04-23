using Revenda.Core.Entities;
using Revenda.Core.UseCases.Revenda.CreateRevenda;

namespace Revenda.Core.Abstractions
{
    public interface IPedidoRepository
    {
        Task<Guid> CreatePedidoAsync(Pedido request, CancellationToken cancellationToken);
        Task<List<Pedido>> GetPedidosAsync(Guid revendaId, CancellationToken cancellationToken);
        Task<List<Pedido>> GetPendingPedidosAsync(CancellationToken cancellationToken);
        Task UpdatePedidosAsync(List<Pedido> pendingPedidos, CancellationToken cancellationToken);
    }
}
