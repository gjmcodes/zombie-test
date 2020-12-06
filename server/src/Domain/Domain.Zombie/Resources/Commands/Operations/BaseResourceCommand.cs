using System;
using Domain.Core.Commands;

namespace Domain.Zombie.Resources.Commands.Operations
{
    public class BaseResourceCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Observations { get; set; }
    }
}