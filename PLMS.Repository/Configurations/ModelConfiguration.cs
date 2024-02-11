using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PLMS.Core.Entities;

namespace PLMS.Repository.Configurations
{
    public class ModelConfiguration:IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Code).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
            builder.Property(x => x.CreatedById).HasMaxLength(40);
            builder.Property(x => x.ModifiedById).HasMaxLength(40);
            builder.Property(x => x.IsDeletedById).HasMaxLength(40);
            builder.Property(x => x.IsDeactivedById).HasMaxLength(40);
        }
    }
}
