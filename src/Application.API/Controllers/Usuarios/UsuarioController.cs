using API.Application.Abstraction.Usuarios.Commands;
using API.Application.Abstraction.Usuarios.Querys;
using API.Application.Abstraction.Usuarios.Response;
using application.API.Controllers.Usuarios.Requests;
using application.API.ViewModel;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ComumResponseViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastrarUsuario([FromBody] AdicionarUsuarioRequest model)
        {
            var command = new AdicionarUsuarioCommand(model.Nome, model.Email);
            await this._mediator.Send(command);

            return Ok();
        }

        [HttpGet("BuscarPorEmail")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ComumResponseViewModel<BuscarUsuarioPorEmailResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarPorEmail([FromQuery] string email)
        {
            var query = new BuscarUsuarioPorEmailQuery(email);
            var response = await this._mediator.Send(query);

            return Ok(response);
        }
    }
}
