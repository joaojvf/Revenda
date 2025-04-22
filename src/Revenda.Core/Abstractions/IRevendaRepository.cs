using Revenda.Core.Entities;
using Revenda.Core.UseCases.Revenda.CreateRevenda;

namespace Revenda.Core.Abstractions
{
    public interface IRevendaRepository
    {
        Task<Guid> CreateRevendaAsync(RevendaEntity request, CancellationToken cancellationToken);
        Task<RevendaEntity?> GetRevendaByCnpjAsync(string cnpj, CancellationToken cancellationToken);
        Task<RevendaEntity?> GetRevendaByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
