using Revenda.Core.UseCases.PedidoFornecedor.CriarPedidoFornecedor;

namespace Revenda.Core.Abstractions
{
    public interface IFornecedorClient
    {
        Task<FornecedorPedidoResponse> EnviarPedidoAsync(FornecedorPedidoRequest pedido, CancellationToken cancellationToken);
    }
}
