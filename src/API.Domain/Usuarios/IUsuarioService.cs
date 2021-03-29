using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Usuarios
{
    public interface IUsuarioService
    {
        Task AdicionarUsuario(string nome, string email);
    }
}
