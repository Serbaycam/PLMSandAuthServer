﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PLMS.Core.Entity;

namespace PLMS.Repository.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.Property(x=>x.CreatedById).HasMaxLength(36);
            builder.Property(x=>x.ModifiedById).HasMaxLength(36);
        }
    }
}