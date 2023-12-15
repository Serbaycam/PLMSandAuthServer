using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PLMS.Core.Entities;

namespace PLMS.Repository.Configurations
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.ItemCode).IsRequired().HasMaxLength(20);
            builder.Property(x => x.ItemName).IsRequired().HasMaxLength(20);
            builder.Property(x => x.CreatedById).HasMaxLength(40);
            builder.Property(x => x.ModifiedById).HasMaxLength(40);
            builder.Property(x => x.IsDeletedById).HasMaxLength(40);
        }
    }
}
