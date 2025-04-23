using MediatR;
using Microsoft.AspNetCore.Mvc;
using Revenda.Core.UseCases.PedidoCliente.ReceberPedidoCliente;
using Revenda.Core.UseCases.Revenda.GetRevendaById;

namespace Revenda.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoClienteController(IMediator mediator) : Controller
    {
        [HttpPost("{revendaId:guid}/pedidos-cliente")]
        [ProducesResponseType(typeof(ReceberPedidoClienteResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ReceberPedidoCliente(Guid revendaId, [FromBody] ReceberPedidoClienteCommand command)
        {
            if (revendaId != command.RevendaId)
            {
                return BadRequest("ID da revenda na rota difere do corpo da requisição.");
            }

            try
            {
                var response = await mediator.Send(command);
                return Created($"/api/pedidos-cliente/{response.PedidoId}", response);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("{revendaId:guid}/pedidos-cliente/{pedidoId:guid}")]
        [ProducesResponseType(typeof(ReceberPedidoClienteResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ReceberPedidoCliente(Guid revendaId, Guid pedidoId)
        {
            try
            {
                var result = await mediator.Send(new GetPedidoClienteByIdQuery(revendaId, pedidoId));
                return result != null ? Ok(result) : NotFound();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
