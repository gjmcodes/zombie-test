using System.Threading.Tasks;
using Domain.Core.Entities;
using Domain.Zombie.Resources.Commands.Operations;
using Domain.Zombie.Resources.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace Domain.Zombie.Resources.Models
{
    public class ResourceRoot : Entity<ResourceRoot>
    {
        private string _previousName;
        public string Name { get; protected set; }
        public int Amount { get; protected set; }
        public string Observations { get; protected set; }

        //EF
        protected ResourceRoot() { }
        public ResourceRoot(AddResourceCommand cmd)
        {
            this.Name = cmd.Name;
            this.Amount = cmd.Amount;
            this.Observations = cmd.Observations;
        }

        public void UpdateResource(UpdateResourceCommand cmd)
        {
            _previousName = this.Name;
            this.Name = cmd.Name;
            this.Amount = cmd.Amount;
            this.Observations = cmd.Observations;
        }

        #region VALIDATIONS
        protected void NameNotEmptyRule()
        {
            this.RuleFor(p => p.Name)
            .Must(p => !string.IsNullOrEmpty(p))
            .WithMessage("O nome do recurso não pode ser vazio");
        }

        protected void AmountEqualsGreaterThanZero()
        {
            this.RuleFor(p => p.Amount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("A quantidade de recurso não pode ser negativa");
        }

        protected void CanUseName(IResourceReadOnlyRepository resourceReadOnly)
        {
            this.RuleFor(p => p.Name)
            .MustAsync(async (name, cancellationToken) =>
            {
                var sameNamesCount = await resourceReadOnly.CountByNameAsync(name);
                return sameNamesCount == 0;
            }).WithMessage("Um recurso de mesmo nome já existe");
        }
        public async Task<ValidationResult> ValidateNewResourceAsync(IResourceReadOnlyRepository resourceReadOnly)
        {
            NameNotEmptyRule();
            AmountEqualsGreaterThanZero();
            CanUseName(resourceReadOnly);

            this.ValidationResult = await ValidateAsync(this);

            return ValidationResult;
        }

        public async Task<ValidationResult> ValidateUpdateResourceAsync(IResourceReadOnlyRepository resourceReadOnly)
        {
            NameNotEmptyRule();
            AmountEqualsGreaterThanZero();

            if (this.Name != _previousName)
                CanUseName(resourceReadOnly);

            this.ValidationResult = await ValidateAsync(this);

            return ValidationResult;
        }
        #endregion
    }
}