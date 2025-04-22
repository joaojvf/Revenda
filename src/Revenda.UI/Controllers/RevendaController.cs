using MediatR;
using Microsoft.AspNetCore.Mvc;
using Revenda.Core.UseCases.GetRevendaById;
using Revenda.Core.UseCases.Revenda.CreateRevenda;

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
    }
}
