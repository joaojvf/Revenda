using FluentValidation.TestHelper;
using Revenda.Core.UseCases.PedidoCliente.ReceberPedidoCliente;

namespace Revenda.Core.Tests.UseCases.PedidoCliente.ReceberPedidoCliente
{
    public class ItemPedidoDtoValidatorTests
    {
        private readonly ItemPedidoDtoValidator _validator = new();

        [Theory]
        [InlineData("produto-123", 1)]
        [InlineData("abc", 10)]
        public void Should_Pass_With_Valid_Values(string produtoId, int quantidade)
        {
            var dto = new ItemPedidoDto(produtoId, quantidade);
            var result = _validator.TestValidate(dto);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData("", 1)]
        [InlineData(null, 1)]
        public void Should_Fail_When_ProdutoId_Is_Empty(string produtoId, int quantidade)
        {
            var dto = new ItemPedidoDto(produtoId!, quantidade);
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.ProdutoId);
        }

        [Theory]
        [InlineData("produto-123", 0)]
        [InlineData("produto-123", -1)]
        public void Should_Fail_When_Quantidade_Is_Invalid(string produtoId, int quantidade)
        {
            var dto = new ItemPedidoDto(produtoId, quantidade);
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Quantidade);
        }
    }

    public class ReceberPedidoClienteCommandValidatorTests
    {
        private readonly ReceberPedidoClienteCommandValidator _validator = new();

        [Theory, AutoMoqData]
        public void Should_Pass_With_Valid_Command(Guid revendaId, string identificacao)
        {
            var command = new ReceberPedidoClienteCommand
            {
                RevendaId = revendaId,
                IdentificacaoCliente = identificacao,
                Itens = new()
            {
                new ItemPedidoDto ( "123", 2 )
            }
            };

            var result = _validator.TestValidate(command);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory, AutoMoqData]
        public void Should_Fail_When_IdentificacaoCliente_Is_Empty(Guid revendaId)
        {
            var command = new ReceberPedidoClienteCommand
            {
                RevendaId = revendaId,
                IdentificacaoCliente = "",
                Itens = new()
            {
                new ItemPedidoDto ("123", 1 )
            }
            };

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.IdentificacaoCliente);
        }

        [Theory, AutoMoqData]
        public void Should_Fail_When_Itens_Is_Empty(Guid revendaId, string identificacao)
        {
            var command = new ReceberPedidoClienteCommand
            {
                RevendaId = revendaId,
                IdentificacaoCliente = identificacao,
                Itens = []
            };

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Itens);
        }

        [Theory, AutoMoqData]
        public void Should_Fail_When_RevendaId_Is_Empty(string identificacao)
        {
            var command = new ReceberPedidoClienteCommand
            {
                RevendaId = Guid.Empty,
                IdentificacaoCliente = identificacao,
                Itens = new() { new ItemPedidoDto("abc", 1) }
            };

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.RevendaId);
        }
    }


}
