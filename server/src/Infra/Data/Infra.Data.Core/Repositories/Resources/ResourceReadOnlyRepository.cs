using System.Linq;
using System.Threading.Tasks;
using Domain.Zombie.Resources.Models;
using Domain.Zombie.Resources.Repositories;
using Infra.Data.Core.Contexts;
using Infra.Data.Core.Core;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Core.Repositories.Resources
{
    public class ResourceReadOnlyRepository : BaseReadOnlyRepository<ResourceRoot>,
    IResourceReadOnlyRepository
    {
        public ResourceReadOnlyRepository(ZombieDbContext context) : base(context)
        {
        }

        public async Task<int> CountByNameAsync(string name)
        {
            var count = await base._dbSet.AsQueryable().Where(x => x.Name.ToUpper() == name.ToUpper())
            .CountAsync();

            return count;
        }
    }
}