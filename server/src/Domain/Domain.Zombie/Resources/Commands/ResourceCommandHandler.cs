using System.Threading;
using System.Threading.Tasks;
using Domain.Core.Commands;
using Domain.Core.Operations;
using Domain.Zombie.Resources.Commands.Operations;
using Domain.Zombie.Resources.Models;
using Domain.Zombie.Resources.Repositories;
using MediatR;

namespace Domain.Zombie.Resources.Commands
{
    public class ResourceCommandHandler : CommandHandler
    , IRequestHandler<AddResourceCommand, CommandResult>
    , IRequestHandler<UpdateResourceCommand, CommandResult>
    , IRequestHandler<DeleteResourceCommand, CommandResult>

    {
        private readonly IResourcePersistentRepository _resourcePersistentRepository;
        private readonly IResourceReadOnlyRepository _resourceReadOnlyRepository;
        public ResourceCommandHandler(IResourcePersistentRepository resourcePersistentRepository
        , IResourceReadOnlyRepository resourceReadOnlyRepository)
        {
            _resourcePersistentRepository = resourcePersistentRepository;
            _resourceReadOnlyRepository = resourceReadOnlyRepository;
        }

        public async Task<CommandResult> Handle(AddResourceCommand request, CancellationToken cancellationToken)
        {

            var model = new ResourceRoot(request);
            base.CommandResult.ValidationResult = await model.ValidateNewResourceAsync(_resourceReadOnlyRepository);

            if (base.HasErrors)
                return base.CommandResult;

            _resourcePersistentRepository.Add(model);
            await _resourcePersistentRepository.SaveChangesAsync();

            return base.CommandResult;
        }

        public async Task<CommandResult> Handle(UpdateResourceCommand request, CancellationToken cancellationToken)
        {
            var model = await _resourcePersistentRepository.GetByIdAsync(request.Id);
            model.UpdateResource(request);

            base.CommandResult.ValidationResult = await model.ValidateUpdateResourceAsync(_resourceReadOnlyRepository);

            if (base.HasErrors)
                return base.CommandResult;

            _resourcePersistentRepository.Update(model);
            await _resourcePersistentRepository.SaveChangesAsync();

            return base.CommandResult;
        }

        public async Task<CommandResult> Handle(DeleteResourceCommand request, CancellationToken cancellationToken)
        {

            await _resourcePersistentRepository.DeleteAsync(request.Id);
            await _resourcePersistentRepository.SaveChangesAsync();

            return base.CommandResult;
        }
    }
}