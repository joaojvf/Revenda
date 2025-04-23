using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revenda.Core.UseCases.PedidoCliente.ReceberPedidoCliente
{
    public record ItemPedidoDto(string ProdutoId, int Quantidade);

    public record ReceberPedidoClienteCommand : IRequest<ReceberPedidoClienteResponse>
    {
        public Guid RevendaId { get; init; }
        public required string IdentificacaoCliente { get; init; }
        public required List<ItemPedidoDto> Itens { get; init; } = new();
    }

    public record ReceberPedidoClienteResponse
    {
        public Guid PedidoId { get; init; }
        public List<ItemPedidoDto> ItensConfirmados { get; init; } = new();
    }
}
