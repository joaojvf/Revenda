using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Revenda.Core.Abstractions;
using Revenda.Core.Entities;
using Revenda.Core.Tests;
using Revenda.Core.UseCases.PedidoCliente.ReceberPedidoCliente;
using Xunit;

public class ReceberPedidoClienteCommandHandlerTests
{
    [Theory, AutoMoqData]
    public async Task Should_Create_Pedido_Cliente_When_Valid(
        [Frozen] Mock<IRevendaRepository> revendaRepoMock,
        [Frozen] Mock<IPedidoClienteRepository> pedidoRepoMock,
        [Frozen] Mock<IValidator<ReceberPedidoClienteCommand>> validatorMock,
        ReceberPedidoClienteCommand command)
    {
        // Arrange
        var revenda = new RevendaEntity() { Cnpj = "", Email = "", NomeFantasia = "", RazaoSocial = ""};
        revendaRepoMock
            .Setup(r => r.GetRevendaByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(revenda);

        validatorMock
            .Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult());

        var handler = new ReceberPedidoClienteCommandHandler(
            revendaRepoMock.Object,
            pedidoRepoMock.Object,
            validatorMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.Should().NotBeNull();
        result.ItensConfirmados.Should().BeEquivalentTo(command.Itens);
        pedidoRepoMock.Verify(x => x.CreateItemPedidoAsync(It.IsAny<PedidoCliente>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Theory, AutoMoqData]
    public async Task Should_Throw_When_Revenda_Not_Found(
        [Frozen] Mock<IRevendaRepository> revendaRepoMock,
        [Frozen] Mock<IValidator<ReceberPedidoClienteCommand>> validatorMock,
        ReceberPedidoClienteCommand command)
    {
        // Arrange
        revendaRepoMock
            .Setup(r => r.GetRevendaByIdAsync(command.RevendaId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((RevendaEntity?)null);

        var handler = new ReceberPedidoClienteCommandHandler(
            revendaRepoMock.Object,
            Mock.Of<IPedidoClienteRepository>(),
            validatorMock.Object);

        // Act
        Func<Task> act = () => handler.Handle(command, default);

        // Assert
        await act.Should().ThrowAsync<KeyNotFoundException>()
            .WithMessage($"Revenda com ID {command.RevendaId} não encontrada.");
    }

    [Theory, AutoMoqData]
    public async Task Should_Throw_When_Command_Is_Invalid(
        [Frozen] Mock<IRevendaRepository> revendaRepoMock,
        [Frozen] Mock<IValidator<ReceberPedidoClienteCommand>> validatorMock,
        ReceberPedidoClienteCommand command)
    {
        var revenda = new RevendaEntity() { Cnpj = "", Email = "", NomeFantasia = "", RazaoSocial = "" };

        // Arrange
        revendaRepoMock
            .Setup(r => r.GetRevendaByIdAsync(command.RevendaId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(revenda);

        var validationFailures = new List<ValidationFailure>
        {
            new("Itens", "Lista de itens inválida")
        };

        validatorMock
            .Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult(validationFailures));

        var handler = new ReceberPedidoClienteCommandHandler(
            revendaRepoMock.Object,
            Mock.Of<IPedidoClienteRepository>(),
            validatorMock.Object);

        // Act
        Func<Task> act = () => handler.Handle(command, default);

        // Assert
        await act.Should().ThrowAsync<FluentValidation.ValidationException>()
            .Where(e => e.Errors.Any(f => f.PropertyName == "Itens"));
    }
}
