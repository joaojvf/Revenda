using FluentValidation;
using System.Text.RegularExpressions;

namespace Revenda.Core.UseCases.Revenda.CreateRevenda
{
    public class CreateRevendaCommandValidator : AbstractValidator<CreateRevendaCommand>
    {
        public CreateRevendaCommandValidator()
        {
            RuleFor(v => v.Cnpj)
                .NotEmpty().WithMessage("CNPJ é obrigatório.")
                .Length(14).WithMessage("CNPJ deve ter 14 dígitos.")
                .Must(BeAValidCnpj).WithMessage("CNPJ inválido.");

            RuleFor(v => v.RazaoSocial)
                .NotEmpty().WithMessage("Razão Social é obrigatória.")
                .MaximumLength(200).WithMessage("Razão Social não pode exceder 200 caracteres.");

            RuleFor(v => v.NomeFantasia)
                .NotEmpty().WithMessage("Nome Fantasia é obrigatório.")
                .MaximumLength(150).WithMessage("Nome Fantasia não pode exceder 150 caracteres.");

            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("Email é obrigatório.")
                .EmailAddress().WithMessage("Formato de email inválido.")
                .MaximumLength(100).WithMessage("Email não pode exceder 100 caracteres.");

            RuleFor(v => v.NomesContato)
                .NotEmpty().WithMessage("Pelo menos um Nome de Contato é obrigatório.")
                .Must(HaveExactlyOnePrincipal).WithMessage("Deve haver exatamente um contato principal.");

            RuleForEach(v => v.NomesContato).SetValidator(new CreateNomeContatoDtoValidator());

            RuleFor(v => v.EnderecosEntrega)
                .NotEmpty().WithMessage("Pelo menos um Endereço de Entrega é obrigatório.");

            RuleForEach(v => v.EnderecosEntrega).SetValidator(new CreateEnderecoEntregaDtoValidator());

            When(v => v.Telefones != null && v.Telefones.Any(), () =>
            {
                RuleForEach(v => v.Telefones).SetValidator(new CreateTelefoneDtoValidator());
            });
        }

        private bool BeAValidCnpj(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj) || !Regex.IsMatch(cnpj, @"^\d{14}$"))
                return false;
            return true;
        }

        private bool HaveExactlyOnePrincipal(List<CreateNomeContatoDto> contatos)
        {
            return contatos != null && contatos.Count(c => c.IsPrincipal) == 1;
        }
    }

}
