using ClienteProject.Api.Models.Response;
using ClienteProject.Application.UseCases.CadastrarCliente;
using ClienteProject.Application.UseCases.ListarDetalheCliente;
using ClienteProject.Application.UseCases.ListarTodosClientes;
using ClienteProject.Domain.SeedOfWork.Repository.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClienteProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost, Route("CadastrarCliente")]
        [ProducesResponseType(typeof(ApiResponse<CadastrarClienteOutput>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CadastrarClienteAsync([FromBody] CadastrarClienteInput input, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var output = await _mediator.Send(input, cancellationToken);

            return CreatedAtAction(
                nameof(CadastrarClienteAsync),
                new { output.Id },
                new ApiResponse<CadastrarClienteOutput>(output)
            );
        }

        [HttpGet, Route("ListarClientes")]
        [ProducesResponseType(typeof(ListarClientesOutput), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarClientesAsync(CancellationToken cancellationToken,
                                                                [FromQuery] int? page = null,
                                                                [FromQuery(Name = "per_page")] int? perPage = null,
                                                                [FromQuery] string? search = null,
                                                                [FromQuery] string? sort = null,
                                                                [FromQuery] QueryOrder? dir = null)
        {
            var input = new ListarClientesInput
            {
                Page = page ?? 0,
                PerPage = perPage ?? 0,
                Search = search ?? string.Empty,
                Sort = sort ?? string.Empty,
                Dir = dir ?? default
            };

            var output = await _mediator.Send(input, cancellationToken);
            return Ok(new ApiResponseList<ListarClienteModelOutput>(output));
        }


        [HttpGet, Route("ObterDetalheCliente/{id}")]
        [ProducesResponseType(typeof(ObterDetalheClienteOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterDetalheClienteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            if (id == Guid.Empty)
                return BadRequest("O ID do cliente é inválido.");

            var input = new ObterDetalheClienteInput(id);
            var output = await _mediator.Send(input, cancellationToken);

            if (output == null)
                return NotFound($"Cliente com ID {id} não foi encontrado.");

            return Ok(new ApiResponse<ObterDetalheClienteOutput>(output));
        }
    }
}
