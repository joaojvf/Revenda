using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revenda.Core.UseCases.PedidoFornecedor.CriarPedidoFornecedor
{
    public record PedidoItemDto(string CodigoProduto, int Quantidade);
    public record FornecedorPedidoRequest(string CnpjRevenda, string PedidoIdInterno, DateTime DataPedido, List<PedidoItemDto> Itens, int QuantidadeTotalUnidades);

    public record FornecedorPedidoResponse
    {
        public required string FornecedorOrderId { get; init; }
        public required string Status { get; init; }
        public string? Mensagem { get; init; }
    }
}
