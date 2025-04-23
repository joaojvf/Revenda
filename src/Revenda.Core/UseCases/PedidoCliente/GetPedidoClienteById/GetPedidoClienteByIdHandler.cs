using AutoMapper;
using MediatR;
using Revenda.Core.Abstractions;

namespace Revenda.Core.UseCases.Revenda.GetRevendaById
{
    public class GetPedidoClienteByIdHandler(IMapper mapper, IPedidoClienteRepository repository) : IRequestHandler<GetPedidoClienteByIdQuery, PedidoClienteDto?>
    {
        public async Task<PedidoClienteDto?> Handle(GetPedidoClienteByIdQuery request, CancellationToken cancellationToken)
        {
            var pedidoCliente = await repository.GetPedidoClientByIdAsync(request.RevendaId, request.ProductId, cancellationToken);

            if (pedidoCliente == null)
            {
                return null;
            }

            return mapper.Map<PedidoClienteDto>(pedidoCliente);
        }
    }
}
