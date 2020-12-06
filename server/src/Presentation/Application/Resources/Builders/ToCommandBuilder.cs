using System;
using Application.Resources.DTOs;
using Domain.Zombie.Resources.Commands.Operations;

namespace Application.Resources.Builders
{
    public static class ToCommandBuilder
    {
        public static AddResourceCommand MapAddResourceCommand(AddResourceDTO dto)
        {
            return new AddResourceCommand()
            {
                Amount = dto.Amount,
                Name = dto.Name,
                Observations = dto.Observations
            };
        }

        public static UpdateResourceCommand MapUpdateResourceCommand(UpdateResourceDTO dto)
        {
            return new UpdateResourceCommand()
            {
                Id = dto.Id,
                Amount = dto.Amount,
                Name = dto.Name,
                Observations = dto.Observations
            };
        }

        public static DeleteResourceCommand MapDeleteResourceCommand(Guid id)
        {
            return new DeleteResourceCommand()
            {
                Id = id,
            };
        }
    }
}