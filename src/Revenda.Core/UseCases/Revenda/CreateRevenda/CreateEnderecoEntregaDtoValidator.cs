using FluentValidation;

namespace Revenda.Core.UseCases.Revenda.CreateRevenda
{
    public class CreateEnderecoEntregaDtoValidator : AbstractValidator<CreateEnderecoEntregaDto>
    {
        public CreateEnderecoEntregaDtoValidator()
        {
            RuleFor(e => e.Logradouro).NotEmpty().MaximumLength(200);
            RuleFor(e => e.Bairro).NotEmpty().MaximumLength(100);
            RuleFor(e => e.Cidade).NotEmpty().MaximumLength(100);
            RuleFor(e => e.Estado).NotEmpty().Length(2);
            RuleFor(e => e.Cep).NotEmpty().Matches(@"^\d{8}$").WithMessage("CEP inválido.");
        }
    }

}
