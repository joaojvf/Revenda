using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revenda.Core.UseCases.GetRevendaById
{
    public record GetRevendaByIdQuery(Guid Id) : IRequest<RevendaDto?>;

    public record TelefoneDto(Guid Id, string Numero);
    public record NomeContatoDto(Guid Id, string Nome, bool IsPrincipal);
    public record EnderecoEntregaDto(Guid Id, string Logradouro, string? Numero, string? Complemento, string Bairro, string Cidade, string Estado, string Cep);

    public record RevendaDto
    {
        public Guid Id { get; init; }
        public required string Cnpj { get; init; }
        public required string RazaoSocial { get; init; }
        public required string NomeFantasia { get; init; }
        public required string Email { get; init; }
        public List<TelefoneDto> Telefones { get; init; } = new();
        public List<NomeContatoDto> NomesContato { get; init; } = new();
        public List<EnderecoEntregaDto> EnderecosEntrega { get; init; } = new();
    }
}
