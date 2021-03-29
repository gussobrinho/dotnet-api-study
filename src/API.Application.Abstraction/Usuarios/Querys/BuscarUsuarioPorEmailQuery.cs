using API.Application.Abstraction.Usuarios.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Application.Abstraction.Usuarios.Querys
{
    public class BuscarUsuarioPorEmailQuery : IRequest<BuscarUsuarioPorEmailResponse>
    {
        public string Email{ get; set; }

        public BuscarUsuarioPorEmailQuery(string email)
        {
            this.Email = email;
        }
    }
}
