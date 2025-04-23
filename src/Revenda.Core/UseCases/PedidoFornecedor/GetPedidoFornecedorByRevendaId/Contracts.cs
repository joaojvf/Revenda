using MediatR;
using Revenda.Core.Entities;

namespace Revenda.Core.UseCases.PedidoFornecedor.GetPedidoFornecedorByRevendaId
{
    public record GetPedidFornecedorByRevendaIdQuery(Guid RevendaId) : IRequest<List<Pedido>>;
}
