using API.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Domain.Usuarios
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; protected set; }
        public string Email { get; protected set; }


        private Usuario()
        {

        }

        public static Usuario New(string nome, string email)
        {
            var usuario = new Usuario();

            usuario.Nome = nome;
            usuario.Email = email;
            usuario.Ticket = Guid.NewGuid();

            return usuario;
        }
    }
}
