using API.Application.Abstraction.Logins.Commands;
using API.Application.Abstraction.Logins.Responses;
using application.API.Controllers.Logins.Requests;
using application.API.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace application.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ComumResponseViewModel<LoginJWTResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var command = new LoginCommand(model.Email);
            var result = await this._mediator.Send(command);

            return Ok(result);
        }
    }
}
