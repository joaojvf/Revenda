using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revenda.Core.UseCases.PedidoFornecedor.EmitirPedidoFornecedor
{
    public record EmitirPedidoCommand(Guid RevendaId) : IRequest<Guid>;
}
