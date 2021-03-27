using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Usuarios
{
    public class UsuarioService
    {
        public async Task<bool> AdicionarUsuario(string nome, string email)
        {
            var usuario = Usuario.New(nome, email);

            return true;
        }
    }
}
