using System;

namespace Domain.Zombie.Resources.Queries
{
    public struct ResourceIndexingQuery
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Observations { get; set; }

        public ResourceIndexingQuery(Guid id, string name, int amount, string observations)
        {
            this.Id = id;
            this.Name = name;
            this.Amount = amount;
            this.Observations = observations;
        }
    }
}