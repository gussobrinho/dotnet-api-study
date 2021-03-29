using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Domain.Usuarios
{
    public interface IUsuarioRepository
    {
        Task Add(Usuario usuario);
        Task<List<Usuario>> FindAll();
        Task<Usuario> FindByEmail(string email);
    }
}
