using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Application.Abstraction.Usuarios.Commands
{
    public class AdicionarUsuarioCommand : IRequest<bool>
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public AdicionarUsuarioCommand(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
