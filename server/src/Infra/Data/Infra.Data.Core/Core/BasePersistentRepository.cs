using System;
using System.Threading.Tasks;
using Domain.Core.Entities;
using Domain.Core.Repositories;
using Infra.Data.Core.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Core.Core
{
    public class BasePersistentRepository<T> : IPersistentRepository<T> where T : Entity<T>
    {
        private readonly ZombieDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BasePersistentRepository(ZombieDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T Add(T obj)
        {
            _dbSet.Add(obj);
            return obj;
        }

        public async Task<T> DeleteAsync(Guid id)
        {
            var obj = await _dbSet.FindAsync(id);
            _dbSet.Remove(obj);

            return obj;
        }



        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public T Update(T obj)
        {
            _dbSet.Update(obj);
            return obj;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}