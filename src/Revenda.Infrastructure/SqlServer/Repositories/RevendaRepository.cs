using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Revenda.Core.Abstractions;
using Revenda.Core.Entities;
using System.Threading;

namespace Revenda.Infrastructure.SqlServer.Repositories
{
    public class RevendaRepository(ApplicationContext context) : IRevendaRepository
    {
        public async Task<Guid> CreateRevendaAsync(RevendaEntity entity, CancellationToken cancellationToken)
        {

            context.Revendas.Add(entity);
            await context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<RevendaEntity?> GetRevendaByCnpjAsync(string cnpj, CancellationToken cancellationToken) => await context.Revendas.FirstOrDefaultAsync(r => string.Equals(r.Cnpj, cnpj), cancellationToken);

        public async Task<RevendaEntity?> GetRevendaByIdAsync(Guid id, CancellationToken cancellationToken) => await context.Revendas
                .Include(r => r.Telefones)
                .Include(r => r.NomesContato)
            .Include(r => r.EnderecosEntrega)
                .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }
}
