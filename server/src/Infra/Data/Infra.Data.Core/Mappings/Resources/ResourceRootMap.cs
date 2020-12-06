using Domain.Zombie.Resources.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Core.Mappings.Resources
{
    public class ResourceRootMap : BaseEntityMap<ResourceRoot>
    {
        public override void Configure(EntityTypeBuilder<ResourceRoot> builder)
        {
            base.Configure(builder);

            builder.ToTable("Resources");


            builder.Property(p => p.Name)
            .HasColumnType("nvarchar(100)")
            .IsRequired(true);

            builder.Property(p => p.Amount)
            .HasDefaultValue(0)
            .IsRequired(true);

            builder.Property(p => p.Observations)
            .HasColumnType("nvarchar(100)")
            .IsRequired(false);

        }
    }
}