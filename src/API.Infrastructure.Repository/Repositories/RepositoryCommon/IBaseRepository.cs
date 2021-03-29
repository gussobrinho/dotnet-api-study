using API.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure.Repository.Repositories.RepositoryCommon
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid ticket);
        Task<T> SelectAsync(Guid ticket);
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> ExistAsync(Guid ticket);
    }
}
