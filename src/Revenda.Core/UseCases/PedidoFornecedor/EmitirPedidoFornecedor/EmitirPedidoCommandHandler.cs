using MediatR;
using Revenda.Core.Abstractions;
using Revenda.Core.Entities;

namespace Revenda.Core.UseCases.PedidoFornecedor.EmitirPedidoFornecedor
{
    public class EmitirPedidoCommandHandler(IRevendaRepository revendaRepository, IItemPedidoClientRepository itemPedidoClientRepository, IPedidoRepository pedidoRepository) : IRequestHandler<EmitirPedidoCommand, Guid>
    {
        private const int PEDIDO_MINIMO_ = 1000;
        // Injetar o serviço de background job ou fila, se usar essa abordagem para resiliência
        // private readonly IBackgroundJobClient _backgroundJobClient; // Exemplo com Hangfire

        public async Task<Guid> Handle(EmitirPedidoCommand request, CancellationToken cancellationToken)
        {
            var revendaExists = await revendaRepository.GetRevendaByIdAsync(request.RevendaId, cancellationToken) is not null;
            if (!revendaExists)
            {
                throw new KeyNotFoundException($"Revenda com ID {request.RevendaId} não encontrada.");
            }

            var itensConsolidados = await itemPedidoClientRepository.GetItensPedidoClientePendentesAsync(request.RevendaId, cancellationToken);

            if (!itensConsolidados.Any())
            {
                throw new InvalidOperationException("Não há itens de pedidos de clientes pendentes para consolidar.");
            }

            int quantidadeTotal = itensConsolidados!.Sum(x => x.Quantidade);
            
            if (quantidadeTotal < PEDIDO_MINIMO_)
            {
                throw new InvalidOperationException($"O pedido mínimo para a  é de {PEDIDO_MINIMO_} unidades. O total consolidado é {quantidadeTotal}.");
            }

            // 4. Criar a entidade Pedido (ainda sem enviar)
            var novoPedido = new Pedido
            {
                RevendaId = request.RevendaId,
                Status = StatusPedido.Pendente // Status inicial
            };

            itensConsolidados.ForEach(item =>
            {
                novoPedido.Itens.Add(new ItemPedido
                {
                    ProdutoId = item.ProdutoId,
                    Quantidade = item.Quantidade,
                    Pedido = novoPedido
                });
            });

            await pedidoRepository.CreatePedidoAsync(novoPedido, cancellationToken);

            // 5. [RESILIÊNCIA] Enfileirar o envio para a API da 
            // Em vez de chamar a API diretamente aqui, enfileiramos um background job.
            // Isso desacopla o processo e permite retentativas sem bloquear a requisição original.
            // Exemplo com Hangfire:
            // _backgroundJobClient.Enqueue<IApiSender>(sender => sender.SendOrderAsync(novoPedido.Id, CancellationToken.None));

            // Se não usar background job, a chamada à API (com Polly) seria feita aqui ou em um serviço injetado.
            // Mas a abordagem com background job é fortemente recomendada para APIs instáveis.

            // Marcar os PedidosCliente como processados/incluídos no pedido  (opcional)

            return novoPedido.Id; // Retorna o ID do pedido criado (ainda pendente de envio)
        }
    }
}
