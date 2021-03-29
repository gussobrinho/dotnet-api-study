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

        public async Task<bool> DeleteAsync(Guid ticket)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Ticket.Equals(ticket));
                if (result == null)
                    return false;

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                if (item.Ticket == Guid.Empty)
                {
                    item.Ticket = Guid.NewGuid();
                }

                item.CriadoEm = DateTime.Now;
                _dataset.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<bool> ExistAsync(Guid ticket)
        {
            return await _dataset.AnyAsync(p => p.Ticket.Equals(ticket));
        }

        public async Task<T> SelectAsync(Guid ticket)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Ticket.Equals(ticket));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Ticket.Equals(item.Ticket));
                if (result == null)
                    return null;

                item.AtualizadoEm = DateTime.Now;
                item.CriadoEm = result.CriadoEm;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }
    }
}
