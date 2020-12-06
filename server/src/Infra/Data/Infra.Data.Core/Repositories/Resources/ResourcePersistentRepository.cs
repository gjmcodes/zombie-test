using Domain.Zombie.Resources.Models;
using Domain.Zombie.Resources.Repositories;
using Infra.Data.Core.Contexts;
using Infra.Data.Core.Core;

namespace Infra.Data.Core.Repositories.Resources
{
    public class ResourcePersistentRepository : BasePersistentRepository<ResourceRoot>,
    IResourcePersistentRepository
    {
        public ResourcePersistentRepository(ZombieDbContext context) : base(context)
        {
        }
    }
}