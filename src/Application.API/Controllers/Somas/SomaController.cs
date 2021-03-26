using API.Application.Abstraction.Somas.Querys;
using application.API.Controllers.Somas.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace application.API.Controllers.Somas
{
    [ApiController]
    [Route("[controller]")]
    public class SomaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SomaController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("Somar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SomarNumeros([FromQuery] SomarNumerosRequest model)
        {
            var query = new SomarNumerosQuery(model.Numeros);
            var response = await this._mediator.Send(query);

            return Ok(response);
        }
    }
}
