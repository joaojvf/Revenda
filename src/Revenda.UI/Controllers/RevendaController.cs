using MediatR;
using Microsoft.AspNetCore.Mvc;
using Revenda.Core.UseCases.PedidoCliente.ReceberPedidoCliente;
using Revenda.Core.UseCases.PedidoFornecedor.EmitirPedidoFornecedor;
using Revenda.Core.UseCases.PedidoFornecedor.GetPedidoFornecedorByRevendaId;
using Revenda.Core.UseCases.Revenda.CreateRevenda;
using Revenda.Core.UseCases.Revenda.GetRevendaById;

namespace Revenda.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RevendasController(IMediator mediator) : Controller
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateRevenda([FromBody] CreateRevendaCommand command)
        {
            var revendaId = await mediator.Send(command);
            return CreatedAtAction(nameof(GetRevendaById), new { id = revendaId }, new { id = revendaId });
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(RevendaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRevendaById(Guid id)
        {
            var query = new GetRevendaByIdQuery(id);
            var result = await mediator.Send(query);

            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost("{revendaId:guid}/pedidos-fornecedor")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> EmitirPedidoParaFornecedor(Guid revendaId)
        {
            var command = new EmitirPedidoCommand(revendaId);
            try
            {
                var pedidoAmbevId = await mediator.Send(command);
                return Accepted(new { message = "Pedido para Fornecedor aceito para processamento.", pedidoAmbevId = pedidoAmbevId });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpGet("{revendaId:guid}/pedidos-fornecedor")]
        [ProducesResponseType(typeof(RevendaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPedidosFornecedorByRevendaId(Guid revendaId)
        {
            var query = new GetPedidFornecedorByRevendaIdQuery(revendaId);
            var result = await mediator.Send(query);

            return result != null ? Ok(result) : NotFound();
        }
    }
}
