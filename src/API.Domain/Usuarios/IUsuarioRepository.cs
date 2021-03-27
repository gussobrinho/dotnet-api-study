using System.Threading.Tasks;

namespace API.Domain.Usuarios
{
    public interface IUsuarioRepository
    {
        Task Add(Usuario usuario);
    }
}
