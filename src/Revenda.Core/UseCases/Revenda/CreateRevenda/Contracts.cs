using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revenda.Core.UseCases.Revenda.CreateRevenda
{
    public record CreateTelefoneDto(string Numero);
    public record CreateNomeContatoDto(string Nome, bool IsPrincipal);
    public record CreateEnderecoEntregaDto(string Logradouro, string? Numero, string? Complemento, string Bairro, string Cidade, string Estado, string Cep);

    public record CreateRevendaCommand : IRequest<Guid>
    {
        public required string Cnpj { get; init; }
        public required string RazaoSocial { get; init; }
        public required string NomeFantasia { get; init; }
        public required string Email { get; init; }
        public List<CreateTelefoneDto>? Telefones { get; init; } = new();
        public required List<CreateNomeContatoDto> NomesContato { get; init; } = new();
        public required List<CreateEnderecoEntregaDto> EnderecosEntrega { get; init; } = new();
    }

}
