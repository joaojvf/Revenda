using Revenda.Core.Entities;
using Revenda.Core.UseCases.Revenda.CreateRevenda;

namespace Revenda.Core.Abstractions
{
    public interface IPedidoRepository
    {
        Task<Guid> CreatePedidoAsync(Pedido request, CancellationToken cancellationToken);
    }
}
