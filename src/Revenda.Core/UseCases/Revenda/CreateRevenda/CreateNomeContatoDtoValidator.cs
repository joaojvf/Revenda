using FluentValidation;

namespace Revenda.Core.UseCases.Revenda.CreateRevenda
{
    public class CreateNomeContatoDtoValidator : AbstractValidator<CreateNomeContatoDto>
    {
        public CreateNomeContatoDtoValidator()
        {
            RuleFor(c => c.Nome).NotEmpty().MaximumLength(100);
        }
    }

}
