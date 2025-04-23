namespace Revenda.Core.Tests.UseCases.Revenda.CreateRevenda
{
    using AutoFixture;
    using AutoFixture.Xunit2;
    using FluentAssertions;
    using FluentValidation;
    using FluentValidation.Results;
    using global::Revenda.Core.Abstractions;
    using global::Revenda.Core.Entities;
    using global::Revenda.Core.UseCases.Revenda.CreateRevenda;
    using Moq;
    using Xunit;
    using ValidationException = FluentValidation.ValidationException;

    public class CreateRevendaCommandHandlerTests
    {
        [Theory, AutoMoqData]
        public async Task Should_Create_Revenda_When_Valid_Command(
            [Frozen] Mock<IRevendaRepository> repoMock,
            [Frozen] Mock<IValidator<CreateRevendaCommand>> validatorMock,
            CreateRevendaCommand command)
        {
            // Arrange
            var revendaId = Guid.NewGuid();

            validatorMock
                .Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ValidationResult());

            repoMock
                .Setup(r => r.GetRevendaByCnpjAsync(command.Cnpj, It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => null);

            repoMock
                .Setup(r => r.CreateRevendaAsync(It.IsAny<RevendaEntity>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Guid.NewGuid()))
                .Callback<RevendaEntity, CancellationToken>((r, _) => r.Id = revendaId);

            var handler = new CreateRevendaCommandHandler(repoMock.Object, validatorMock.Object);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            result.Should().Be(revendaId);
            repoMock.Verify(r => r.CreateRevendaAsync(It.IsAny<RevendaEntity>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Theory, AutoMoqData]
        public async Task Should_Throw_When_Command_Is_Invalid(
            [Frozen] Mock<IRevendaRepository> repoMock,
            [Frozen] Mock<IValidator<CreateRevendaCommand>> validatorMock,
            CreateRevendaCommand command)
        {
            // Arrange
            var failures = new List<ValidationFailure>
        {
            new("Cnpj", "CNPJ inválido.")
        };

            repoMock
                .Setup(r => r.GetRevendaByCnpjAsync(command.Cnpj, It.IsAny<CancellationToken>()))
                .ReturnsAsync((RevendaEntity)null!);

            validatorMock
                .Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ValidationResult(failures));

            var handler = new CreateRevendaCommandHandler(repoMock.Object, validatorMock.Object);

            // Act
            Func<Task> act = () => handler.Handle(command, default);

            // Assert
            await act.Should().ThrowAsync<ValidationException>()
                .Where(e => e.Errors.Any(f => f.PropertyName == "Cnpj"));
        }
    }

}
