using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revenda.Core.UseCases.PedidoCliente.ReceberPedidoCliente
{
    public class ReceberPedidoClienteCommandValidator : AbstractValidator<ReceberPedidoClienteCommand>
    {
        public ReceberPedidoClienteCommandValidator()
        {
            RuleFor(p => p.RevendaId)
                .NotEmpty().WithMessage("ID da Revenda é obrigatório.");

            RuleFor(p => p.IdentificacaoCliente)
                .NotEmpty().WithMessage("Identificação do Cliente é obrigatória.")
                .MaximumLength(100);

            RuleFor(p => p.Itens)
                .NotEmpty().WithMessage("A lista de itens não pode estar vazia.");

            RuleForEach(p => p.Itens).SetValidator(new ItemPedidoDtoValidator());
        }
    }

    public class ItemPedidoDtoValidator : AbstractValidator<ItemPedidoDto>
    {
        public ItemPedidoDtoValidator()
        {
            RuleFor(i => i.ProdutoId)
                .NotEmpty().WithMessage("ID do Produto é obrigatório.")
                .MaximumLength(50);

            RuleFor(i => i.Quantidade)
                .GreaterThan(0).WithMessage("Quantidade deve ser maior que zero.");
        }
    }
}
