using Ecom.core.Entities;
using Ecom.core.Interfaces;
using Ecom.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity<int>
    {
        private readonly ApplicationDBContext _context;

        public GenericRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

        }

        public IEnumerable<T> GetAll()
        => _context.Set<T>().AsNoTracking().ToList();

        public async Task<T> GetByIdAsync(int id ,  params Expression<Func<T, object>>[] Includes)
        {
            IQueryable<T> query = _context.Set<T>().Where(x=>x.Id==id);

            foreach (var item in Includes)
            {
                query = query.Include(item);

            }
            return await query.FirstOrDefaultAsync();

            
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        =>await _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] Includes)
        {
            var query = _context.Set<T>().AsQueryable();


            // apply any include .

            foreach (var item in Includes)
            {
                query = query.Include(item);
                
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        => await _context.Set<T>().FindAsync(id);

        public async Task UpdateAsync(int id, T entity)
        {
            var Exitingentity = await _context.Set<T>().FindAsync(id);
            
            if (Exitingentity is not null)
            {

                _context.Set<T>().Update(Exitingentity);
                await _context.SaveChangesAsync();

            }
        }
    }
}
