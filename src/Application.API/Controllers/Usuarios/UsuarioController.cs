using API.Application.Abstraction.Usuarios.Commands;
using application.API.Controllers.Usuarios.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace application.API.Controllers.Usuarios
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("Cadastrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SomarNumeros([FromBody] AdicionarUsuarioRequest model)
        {
            var command = new AdicionarUsuarioCommand(model.Nome, model.Email);
            var response = await this._mediator.Send(command);

            return Ok(response);
        }
    }
}
