using Microsoft.Extensions.Logging;
using Revenda.Core.Abstractions;
using Revenda.Core.UseCases.PedidoFornecedor.CriarPedidoFornecedor;

namespace Revenda.Infrastructure.Gateways
{
    public class FornecedorClientMock(HttpClient client, ILogger<FornecedorClientMock> logger) : IFornecedorClient
    {
        private readonly Random _random = new Random();

        public async Task<FornecedorPedidoResponse> EnviarPedidoAsync(FornecedorPedidoRequest pedido, CancellationToken cancellationToken)
        {
            logger.LogInformation("Simulando envio de pedido para fornecedor para Revenda {Cnpj} (Pedido Interno: {PedidoId})",
            pedido.CnpjRevenda, pedido.PedidoIdInterno);

            await Task.Delay(_random.Next(500, 3000), cancellationToken);

            if (_random.NextDouble() < 0.3)
            {
                logger.LogWarning("Simulando falha na API da fornecedor para o pedido {PedidoId}", pedido.PedidoIdInterno);
                throw new HttpRequestException("Simulação: Erro de comunicação com a API da fornecedor (503 Service Unavailable)");
            }

            var fornecedorOrderId = $"fornecedor_{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
            logger.LogInformation("Simulando sucesso no envio para fornecedor. Pedido {PedidoId} recebeu ID fornecedor: {fornecedorOrderId}",
                 pedido.PedidoIdInterno, fornecedorOrderId);

            return new FornecedorPedidoResponse
            {
                FornecedorOrderId = fornecedorOrderId,
                Status = "Recebido",
                Mensagem = "Pedido recebido com sucesso pelo fornecedor (simulado)."
            };
        }
    }
}

