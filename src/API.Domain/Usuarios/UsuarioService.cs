using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            this._repository = repository;
        }

        public async Task AdicionarUsuario(string nome, string email)
        {
            var usuario = Usuario.New(nome, email);

            await this._repository.Add(usuario);
        }
    }
}
