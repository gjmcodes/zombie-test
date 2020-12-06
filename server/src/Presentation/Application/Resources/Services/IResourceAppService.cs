using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Resources.DTOs;
using Domain.Core.Operations;
using Domain.Zombie.Resources.Queries;

namespace Application.Resources.Services
{
    public interface IResourceAppService : IDisposable
    {
         Task<CommandResult> AddResourceAsync(AddResourceDTO dto);
         Task<CommandResult> UpdateResourceAsync(UpdateResourceDTO dto);
         Task<CommandResult> DeleteResourceAsync(Guid id);
         Task<IEnumerable<ResourceIndexingQuery>> GetAllAsync();
    }
}