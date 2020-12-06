using System.Collections.Generic;
using Domain.Zombie.Resources.Models;
using Domain.Zombie.Resources.Queries;

namespace Application.Resources.Builders
{
    public static class ToQueryBuilder
    {
        public static ResourceIndexingQuery MapAddResourceCommand(ResourceRoot model)
        {
            return new ResourceIndexingQuery
            (
                model.Id
                , model.Name
                , model.Amount
                , model.Observations
            );
        }

        public static IEnumerable<ResourceIndexingQuery> MapAddResourceCommand(IEnumerable<ResourceRoot> models)
        {
            var queries = new List<ResourceIndexingQuery>();

            foreach (var item in models)
            {
                queries.Add(ToQueryBuilder.MapAddResourceCommand(item));
            }

            return queries;
        }
    }
}