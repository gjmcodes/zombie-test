using Domain.Zombie.Resources.Commands.Operations;

namespace Application.Resources.DTOs
{
    public class AddResourceDTO
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Observations { get; set; }

     
    }
}