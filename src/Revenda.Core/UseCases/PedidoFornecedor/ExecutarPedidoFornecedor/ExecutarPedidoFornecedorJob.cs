using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Revenda.Core.Abstractions;
using Revenda.Core.Entities;

namespace Revenda.Core.UseCases.PedidoFornecedor.CriarPedidoFornecedor
{
    public class ExecutarPedidoFornecedorJob(ILogger<ExecutarPedidoFornecedorJob> logger, IServiceProvider serviceProvider) : BackgroundService
    {
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = serviceProvider.CreateScope();
                    var pedidoRepository = scope.ServiceProvider.GetRequiredService<IPedidoRepository>();
                     var fornecedorClient = scope.ServiceProvider.GetRequiredService<IFornecedorClient>();

                    var pendingPedidos = await pedidoRepository.GetPendingPedidosAsync(stoppingToken);
                    foreach (var pedido in pendingPedidos)
                    {
                        try
                        {
                            var pedidoItemDtos = pedido.Itens.Select(x => new PedidoItemDto(x.ProdutoId, x.Quantidade)).ToList();
                            await fornecedorClient.EnviarPedidoAsync(new FornecedorPedidoRequest(
                                pedido.Revenda.Cnpj,
                                pedido.Id.ToString(),
                                pedido.DataCriacao,
                                pedidoItemDtos,
                                pedido.QuantidadeTotal
                                ), stoppingToken);

                            pedido.Status = StatusPedido.Enviado;
                        }
                        catch (Exception ex)
                        {
                            pedido.Status = StatusPedido.Falhou;
                            logger.LogError(ex, $"Failed to send pedido {pedido.Id}");
                        }
                    }

                    await pedidoRepository.UpdatePedidosAsync(pendingPedidos, stoppingToken);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Unhandled error in CriarPedidoFornecedorJob");
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
