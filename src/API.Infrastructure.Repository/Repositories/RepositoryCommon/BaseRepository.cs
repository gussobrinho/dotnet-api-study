using API.Domain.Common;
using API.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure.Repository.Repositories.RepositoryCommon
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {

        protected readonly ApiDbContext _context;
        private DbSet<T> _dataset;
        public BaseRepository(ApiDbContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        //Testar
        //public DbSet<T> EntitySet { get => _dataset; }

        public async Task<bool> DeleteAsync(Guid ticket)
        {

            var result = await _dataset.SingleOrDefaultAsync(p => p.Ticket.Equals(ticket));
            if (result == null)
                return false;

            _dataset.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<T> InsertAsync(T item)
        {
            if (item.Ticket == Guid.Empty)
            {
                item.Ticket = Guid.NewGuid();
            }

            item.CriadoEm = DateTime.Now;
            _dataset.Add(item);

            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<bool> ExistAsync(Guid ticket)
        {
            return await _dataset.AnyAsync(p => p.Ticket.Equals(ticket));
        }

        public async Task<T> SelectAsync(Guid ticket)
        {
            return await _dataset.SingleOrDefaultAsync(p => p.Ticket.Equals(ticket));
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            return await _dataset.ToListAsync();
        }

        public async Task<T> UpdateAsync(T item)
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Ticket.Equals(item.Ticket));
            if (result == null)
                return null;

            item.AtualizadoEm = DateTime.Now;
            item.CriadoEm = result.CriadoEm;

            _context.Entry(result).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();

            return item;
        }
    }
}
