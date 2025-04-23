using FluentValidation.TestHelper;
using Revenda.Core.UseCases.Revenda.CreateRevenda;

namespace Revenda.Core.Tests.UseCases.Revenda.CreateRevenda
{

    public class CreateTelefoneDtoValidatorTests
    {
        private readonly CreateTelefoneDtoValidator _validator = new();

        [Theory]
        [InlineData("+5511987654321")]
        [InlineData("11987654321")]
        public void Should_Pass_With_Valid_Number(string number)
        {
            var dto = new CreateTelefoneDto(number);
            var result = _validator.TestValidate(dto);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData("")]
        [InlineData("abc123")]
        public void Should_Fail_With_Invalid_Number(string number)
        {
            var dto = new CreateTelefoneDto(number);
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Numero);
        }
    }

    public class CreateNomeContatoDtoValidatorTests
    {
        private readonly CreateNomeContatoDtoValidator _validator = new();

        [Theory]
        [InlineData("João", true)]
        [InlineData("Ana", false)]
        public void Should_Pass_With_Valid_Names(string nome, bool isPrincipal)
        {
            var dto = new CreateNomeContatoDto(nome, isPrincipal);
            var result = _validator.TestValidate(dto);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_Fail_With_Empty_Name(string nome)
        {
            var dto = new CreateNomeContatoDto(nome!, true);
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Nome);
        }
    }

    public class CreateRevendaCommandValidatorTests
    {
        private readonly CreateRevendaCommandValidator _validator = new();

        [Theory, AutoMoqData]
        public void Should_Validate_Valid_Command(string cnpj, string razao, string fantasia)
        {
            var command = new CreateRevendaCommand
            {
                Cnpj = "12345678000195", // válido (estrutura)
                RazaoSocial = razao,
                NomeFantasia = fantasia,
                Email = "test@hotmail.com",
                Telefones = new() { new("+5511987654321") },
                NomesContato = new() { new("João", true) },
                EnderecosEntrega = new() {
                new("Rua X", "10", "", "Bairro", "Cidade", "SP", "12345678")
            }
            };

            var result = _validator.TestValidate(command);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Should_Fail_If_ContatoPrincipal_Is_Missing()
        {
            var command = new CreateRevendaCommand
            {
                Cnpj = "12345678000195",
                RazaoSocial = "Empresa X",
                NomeFantasia = "Fantasia X",
                Email = "email@email.com",
                NomesContato = new() { new("Contato 1", false), new("Contato 2", false) },
                EnderecosEntrega = new() {
                new("Rua X", "10", "", "Bairro", "Cidade", "SP", "12345678")
            }
            };

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.NomesContato)
                  .WithErrorMessage("Deve haver exatamente um contato principal.");
        }
    }
}
