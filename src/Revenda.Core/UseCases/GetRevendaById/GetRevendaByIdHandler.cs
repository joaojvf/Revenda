using AutoMapper;
using MediatR;
using Revenda.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revenda.Core.UseCases.GetRevendaById
{
    public class GetRevendaByIdHandler(IMapper mapper, IRevendaRepository repository) : IRequestHandler<GetRevendaByIdQuery, RevendaDto?>
    {
        public async Task<RevendaDto?> Handle(GetRevendaByIdQuery request, CancellationToken cancellationToken)
        {
            var revenda = await repository.GetRevendaByIdAsync(request.Id, cancellationToken);

            if (revenda == null)
            {
                return null;
            }

            return mapper.Map<RevendaDto>(revenda);
        }
    }
}
