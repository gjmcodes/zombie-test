using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Entities;
using Domain.Core.Repositories;
using Infra.Data.Core.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Core.Core
{
    public class BaseReadOnlyRepository<T> : IReadOnlyRepository<T> where T : Entity<T>
    {
        private readonly ZombieDbContext _context;
        protected DbSet<T> _dbSet;
        public BaseReadOnlyRepository(ZombieDbContext context)
        {
            _context = context;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            _context.ChangeTracker.LazyLoadingEnabled = false;
            _context.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;

            _dbSet = context.Set<T>();

        }

        public virtual void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToArrayAsync();
        }

        public async Task<T> GetAsync(Guid id)
        {
            var obj = await _dbSet.FindAsync(id);
            return obj;
        }
    }
}