using FluentValidation;
using MediatR;
using Revenda.Core.Abstractions;
using Revenda.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revenda.Core.UseCases.Revenda.CreateRevenda
{
    public class CreateRevendaCommandHandler(IRevendaRepository repo, IValidator<CreateRevendaCommand> validator) : IRequestHandler<CreateRevendaCommand, Guid>
    {
        public async Task<Guid> Handle(CreateRevendaCommand request, CancellationToken cancellationToken)
        {
            var revendaIsNull = await repo.GetRevendaByCnpjAsync(request.Cnpj, cancellationToken) is null;
            if (!revendaIsNull)
            {
                throw new System.ComponentModel.DataAnnotations.ValidationException($"Já existe uma revenda com o CNPJ {request.Cnpj}.");
            }

            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors);
            }

            var revenda = new RevendaEntity
            {
                Cnpj = request.Cnpj,
                RazaoSocial = request.RazaoSocial,
                NomeFantasia = request.NomeFantasia,
                Email = request.Email
            };

            request.Telefones?.ForEach(t => revenda.Telefones.Add(new Telefone { Numero = t.Numero, Revenda = revenda }));
            request.NomesContato.ForEach(nc => revenda.NomesContato.Add(new NomeContato { Nome = nc.Nome, IsPrincipal = nc.IsPrincipal, Revenda = revenda }));
            request.EnderecosEntrega.ForEach(ee => revenda.EnderecosEntrega.Add(new EnderecoEntrega
            {
                Logradouro = ee.Logradouro,
                Numero = ee.Numero,
                Complemento = ee.Complemento,
                Bairro = ee.Bairro,
                Cidade = ee.Cidade,
                Estado = ee.Estado,
                Cep = ee.Cep,
                Revenda = revenda
            }));


            await repo.CreateRevendaAsync(revenda, cancellationToken);

            return revenda.Id;
        }
    }
}
