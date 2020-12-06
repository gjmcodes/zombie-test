using System.Threading.Tasks;
using Domain.Core.Repositories;
using Domain.Zombie.Resources.Models;

namespace Domain.Zombie.Resources.Repositories
{
    public interface IResourceReadOnlyRepository : IReadOnlyRepository<ResourceRoot>
    {
         Task<int> CountByNameAsync(string name); 
    }
}