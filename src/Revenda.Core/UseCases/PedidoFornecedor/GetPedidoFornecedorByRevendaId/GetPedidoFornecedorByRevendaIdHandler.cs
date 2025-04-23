using MediatR;
using Revenda.Core.Abstractions;
using Revenda.Core.Entities;

namespace Revenda.Core.UseCases.PedidoFornecedor.GetPedidoFornecedorByRevendaId
{
    public class GetPedidoFornecedorByRevendaIdHandler(IPedidoRepository repository) : IRequestHandler<GetPedidFornecedorByRevendaIdQuery, List<Pedido>>
    {
        public async Task<List<Pedido>> Handle(GetPedidFornecedorByRevendaIdQuery request, CancellationToken cancellationToken)
        {
            var pedidos = await repository.GetPedidosAsync(request.RevendaId, cancellationToken);
            return pedidos?.Any() is false ? null : pedidos;
        }
    }
}
