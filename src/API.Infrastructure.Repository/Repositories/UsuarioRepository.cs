using API.Domain.Usuarios;
using API.Infrastructure.Repository.Context;
using API.Infrastructure.Repository.Repositories.RepositoryCommon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Infrastructure.Repository.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApiDbContext context)
            : base(context)
        {

        }

        public async Task Add(Usuario usuario)
        {
            await base.InsertAsync(usuario);
        }

        public async Task<List<Usuario>> FindAll()
        {
            return await base.EntitySet.ToListAsync();
        }

        public async Task<Usuario> FindByEmail(string email)
        {
            return await base.EntitySet.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
