using System;
using System.Threading.Tasks;
using Domain.Core.Entities;

namespace Domain.Core.Repositories
{
    public interface IPersistentRepository<T> : IRepository where T : Entity<T>
    {
        T Add(T obj);
        T Update(T obj);
        Task<T> DeleteAsync(Guid id);
        Task<T> GetByIdAsync(Guid id);
        Task<int> SaveChangesAsync();

    }
}