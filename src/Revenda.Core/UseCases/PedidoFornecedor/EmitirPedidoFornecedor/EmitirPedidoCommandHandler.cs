using MediatR;
using Revenda.Core.Abstractions;
using Revenda.Core.Entities;
using Revenda.Core.UseCases.PedidoFornecedor.CriarPedidoFornecedor;

namespace Revenda.Core.UseCases.PedidoFornecedor.EmitirPedidoFornecedor
{
    public class EmitirPedidoCommandHandler(
        IRevendaRepository revendaRepository,
        IItemPedidoClientRepository itemPedidoClientRepository,
        IPedidoRepository pedidoRepository,
        IMediator mediator) : IRequestHandler<EmitirPedidoCommand, Guid>
    {
        private const int PEDIDO_MINIMO_ = 1000;

        public async Task<Guid> Handle(EmitirPedidoCommand request, CancellationToken cancellationToken)
        {
            var revendaIsNull = await revendaRepository.GetRevendaByIdAsync(request.RevendaId, cancellationToken) is null;
            if (revendaIsNull)
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

            var novoPedido = new Pedido
            {
                RevendaId = request.RevendaId,
                Status = StatusPedido.Pendente
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
            return novoPedido.Id;
        }
    }
}
