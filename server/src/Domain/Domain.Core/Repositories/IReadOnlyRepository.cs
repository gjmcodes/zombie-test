using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Entities;

namespace Domain.Core.Repositories
{
    public interface IReadOnlyRepository<T> : IRepository where T : Entity<T>
    {
         Task<IEnumerable<T>> GetAllAsync();
         Task<T> GetAsync(Guid id);

    }
}