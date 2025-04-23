using MediatR;

namespace Revenda.Core.UseCases.Revenda.GetRevendaById
{
    public record GetPedidoClienteByIdQuery(Guid RevendaId, Guid ProductId) : IRequest<PedidoClienteDto?>;
    public record ItemPedidoClienteDto(Guid Id, int Quantidade);

    public class PedidoClienteDto
    {
        public Guid Id { get; init; }
        public Guid RevendaId { get; init; }
        public DateTime DataPedido { get; init; }
        public List<ItemPedidoClienteDto> Itens { get; init; } = new();

    }
}
