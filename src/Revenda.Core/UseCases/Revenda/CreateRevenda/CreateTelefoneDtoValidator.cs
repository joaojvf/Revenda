using FluentValidation;

namespace Revenda.Core.UseCases.Revenda.CreateRevenda
{
    public class CreateTelefoneDtoValidator : AbstractValidator<CreateTelefoneDto>
    {
        public CreateTelefoneDtoValidator()
        {
            RuleFor(t => t.Numero)
                .NotEmpty()
                .MaximumLength(20)
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Número de telefone inválido (ex: +5511987654321 ou 11987654321)."); // Exemplo E.164 simplificado
        }
    }

}
