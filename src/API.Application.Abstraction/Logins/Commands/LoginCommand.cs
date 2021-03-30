using API.Application.Abstraction.Logins.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Application.Abstraction.Logins.Commands
{
    public class LoginCommand : IRequest<LoginJWTResponse>
    {
        public string Email { get; set; }

        public LoginCommand(string email)
        {
            this.Email = email;
        }
    }
}
