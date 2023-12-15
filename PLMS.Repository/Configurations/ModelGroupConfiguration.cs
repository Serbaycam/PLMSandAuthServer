using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PLMS.Core.Entities;

namespace PLMS.Repository.Configurations
{
    public class ModelGroupConfiguration : IEntityTypeConfiguration<ModelGroup>
    {
        public void Configure(EntityTypeBuilder<ModelGroup> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.ItemCode).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ItemName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreatedById).HasMaxLength(40);
            builder.Property(x => x.ModifiedById).HasMaxLength(40);
            builder.Property(x => x.IsDeletedById).HasMaxLength(40);
        }
    }
}
