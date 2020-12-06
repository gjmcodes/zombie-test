using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Resources.Builders;
using Application.Resources.DTOs;
using Domain.Core.Operations;
using Domain.Zombie.Resources.Queries;
using Domain.Zombie.Resources.Repositories;
using MediatR;

namespace Application.Resources.Services
{
    public class ResourceAppService : IResourceAppService
    {
        private readonly IMediator mediator;
        private readonly IResourceReadOnlyRepository _resourceReadOnlyRepository;
        public ResourceAppService(IMediator mediator
        , IResourceReadOnlyRepository resourceReadOnlyRepository)
        {
            this.mediator = mediator;
            _resourceReadOnlyRepository = resourceReadOnlyRepository;
        }

        public async Task<CommandResult> AddResourceAsync(AddResourceDTO dto)
        {
            var cmd = ToCommandBuilder.MapAddResourceCommand(dto);

            var commandResult = await mediator.Send(cmd);

            return commandResult;
        }


        public async Task<CommandResult> UpdateResourceAsync(UpdateResourceDTO dto)
        {
            var cmd = ToCommandBuilder.MapUpdateResourceCommand(dto);

            var commandResult = await mediator.Send(cmd);

            return commandResult;
        }

        public async Task<CommandResult> DeleteResourceAsync(Guid id)
        {
            var cmd = ToCommandBuilder.MapDeleteResourceCommand(id);

            var commandResult = await mediator.Send(cmd);

            return commandResult;
        }

        public async Task<IEnumerable<ResourceIndexingQuery>> GetAllAsync()
        {
            var resources = await _resourceReadOnlyRepository.GetAllAsync();

            var queries = ToQueryBuilder.MapAddResourceCommand(resources);

            return queries;
        }

        public async Task<ResourceIndexingQuery> GetAsync(Guid id)
        {
            var resource = await _resourceReadOnlyRepository.GetAsync(id);

            var query = ToQueryBuilder.MapAddResourceCommand(resource);

            return query;
        }


        public void Dispose()
        {
            _resourceReadOnlyRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}