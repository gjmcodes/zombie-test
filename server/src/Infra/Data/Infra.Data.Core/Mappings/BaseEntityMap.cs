using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Core.Mappings
{
    public class BaseEntityMap<T> : IEntityTypeConfiguration<T> where T : Entity<T>
    {
        public virtual void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<T> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Ignore(p => p.CascadeMode);
            builder.Ignore(p => p.ValidationResult);
        }
    }
}