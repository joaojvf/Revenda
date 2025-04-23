using FluentValidation;

namespace Revenda.Core.UseCases.PedidoCliente.ReceberPedidoCliente
{
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
