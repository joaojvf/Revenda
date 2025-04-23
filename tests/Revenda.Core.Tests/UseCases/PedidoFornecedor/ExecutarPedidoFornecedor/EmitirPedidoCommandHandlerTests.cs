using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using Revenda.Core.Abstractions;
using Revenda.Core.Entities;
using Revenda.Core.Tests;
using Revenda.Core.UseCases.PedidoFornecedor.EmitirPedidoFornecedor;

public class EmitirPedidoCommandHandlerTests
{
    [Theory, AutoMoqData]
    public async Task Should_Throw_When_Revenda_Not_Found(
        [Frozen] Mock<IRevendaRepository> revendaRepoMock,
        EmitirPedidoCommand command,
        EmitirPedidoCommandHandler handler)
    {
        revendaRepoMock.Setup(x => x.GetRevendaByIdAsync(command.RevendaId, It.IsAny<CancellationToken>()))
                       .ReturnsAsync((RevendaEntity?)null);

        var act = () => handler.Handle(command, CancellationToken.None);

        await act.Should().ThrowAsync<KeyNotFoundException>()
            .WithMessage($"Revenda com ID {command.RevendaId} não encontrada.");
    }

    [Theory, AutoMoqData]
    public async Task Should_Throw_When_No_Pending_Items(
        [Frozen] Mock<IRevendaRepository> revendaRepoMock,
        [Frozen] Mock<IItemPedidoClientRepository> itemRepoMock,
        EmitirPedidoCommand command,
        EmitirPedidoCommandHandler handler)
    {
        var revenda = new RevendaEntity() { Cnpj = "", Email = "", NomeFantasia = "", RazaoSocial = "" };
        List<ItemPedidoClienteGrouped> groupedItens = new List<ItemPedidoClienteGrouped>();

        revendaRepoMock
            .Setup(x => x.GetRevendaByIdAsync(command.RevendaId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(revenda);

        itemRepoMock
            .Setup(x => x.GetItensPedidoClientePendentesAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(groupedItens);

        var act = () => handler.Handle(command, CancellationToken.None);

        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("Não há itens de pedidos de clientes pendentes para consolidar.");
    }

    [Theory, AutoMoqData]
    public async Task Should_Throw_When_Total_Quantity_Is_Less_Than_Minimum(
        [Frozen] Mock<IRevendaRepository> revendaRepoMock,
        [Frozen] Mock<IItemPedidoClientRepository> itemRepoMock,
        EmitirPedidoCommand command,
        EmitirPedidoCommandHandler handler)
    {
        var revenda = new RevendaEntity() { Cnpj = "", Email = "", NomeFantasia = "", RazaoSocial = "" };

        revendaRepoMock.Setup(x => x.GetRevendaByIdAsync(command.RevendaId, It.IsAny<CancellationToken>()))
                       .ReturnsAsync(revenda);

        var itens = new List<ItemPedidoClienteGrouped>
        {
            new("PROD1", 200 ),
            new("PROD2", 300 )
        };

        itemRepoMock.Setup(x => x.GetItensPedidoClientePendentesAsync(command.RevendaId, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(itens);

        var act = () => handler.Handle(command, CancellationToken.None);

        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("*pedido mínimo*");
    }

    [Theory, AutoMoqData]
    public async Task Should_Create_Pedido_When_Valid(
        [Frozen] Mock<IRevendaRepository> revendaRepoMock,
        [Frozen] Mock<IItemPedidoClientRepository> itemRepoMock,
        [Frozen] Mock<IPedidoRepository> pedidoRepoMock,
        EmitirPedidoCommand command,
        EmitirPedidoCommandHandler handler)
    {
        var pedidoId = Guid.NewGuid();
        var revenda = new RevendaEntity() { Cnpj = "", Email = "", NomeFantasia = "", RazaoSocial = "" };

        revendaRepoMock.Setup(x => x.GetRevendaByIdAsync(command.RevendaId, It.IsAny<CancellationToken>()))
                       .ReturnsAsync(revenda);

        var itens = new List<ItemPedidoClienteGrouped>
        {
            new("PROD1", 2000 ),
            new("PROD2", 300 )
        };

        itemRepoMock.Setup(x => x.GetItensPedidoClientePendentesAsync(command.RevendaId, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(itens);

        pedidoRepoMock
            .Setup(x => x.CreatePedidoAsync(It.IsAny<Pedido>(), It.IsAny<CancellationToken>()))
            .Callback<Pedido, CancellationToken>((pedido, _) => pedido.Id = pedidoId)
            .Returns(Task.FromResult(Guid.NewGuid()));

        var result = await handler.Handle(command, CancellationToken.None);

        result.Should().Be(pedidoId);
        pedidoRepoMock.Verify(x => x.CreatePedidoAsync(It.IsAny<Pedido>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
