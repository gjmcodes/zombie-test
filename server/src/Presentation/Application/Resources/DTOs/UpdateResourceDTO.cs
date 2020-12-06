using System;

namespace Application.Resources.DTOs
{
    public class UpdateResourceDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Observations { get; set; }
    }
}