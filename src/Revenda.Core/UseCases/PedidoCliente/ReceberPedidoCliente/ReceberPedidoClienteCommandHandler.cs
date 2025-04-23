using FluentValidation;
using MediatR;
using Revenda.Core.Abstractions;
using Revenda.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revenda.Core.UseCases.PedidoCliente.ReceberPedidoCliente
{
    public class ReceberPedidoClienteCommandHandler(
        IRevendaRepository revendaRepository,
        IPedidoClienteRepository pedidoClienteRepository,
        IValidator<ReceberPedidoClienteCommand> validator) : IRequestHandler<ReceberPedidoClienteCommand, ReceberPedidoClienteResponse>
    {
        public async Task<ReceberPedidoClienteResponse> Handle(ReceberPedidoClienteCommand request, CancellationToken cancellationToken)
        {
            var revendaExists = await revendaRepository.GetRevendaByIdAsync(request.RevendaId, cancellationToken) is not null;
            if (!revendaExists)
            {
                throw new KeyNotFoundException($"Revenda com ID {request.RevendaId} não encontrada.");
            }

            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors);
            }

            var novoPedido = new Entities.PedidoCliente
            {
                RevendaId = request.RevendaId,
                IdentificacaoCliente = request.IdentificacaoCliente
            };

            request.Itens.ForEach(itemDto =>
            {
                novoPedido.Itens.Add(new ItemPedidoCliente
                {
                    ProdutoId = itemDto.ProdutoId,
                    Quantidade = itemDto.Quantidade,
                    PedidoCliente = novoPedido
                });
            });

            await pedidoClienteRepository.CreateItemPedidoAsync(novoPedido, cancellationToken);
            var response = new ReceberPedidoClienteResponse
            {
                PedidoId = novoPedido.Id,
                ItensConfirmados = request.Itens
            };

            return response;
        }
    }
}
