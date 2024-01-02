using Microsoft.EntityFrameworkCore;
using PLMS.Core.Entities;
using PLMS.Core.Entity;
using System.Reflection;

namespace PLMS.Repository.Contexts
{
    public class PLMSDbContext(DbContextOptions<PLMSDbContext> options) : DbContext(options)
    {
        DbSet<Color> Colors { get; set; }
        DbSet<Model> Models { get; set; }
        DbSet<ModelGroup> ModelGroups { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<OrderItemRecipe> OrderItemRecipes { get; set; }
        DbSet<Size> Sizes { get; set; }
        DbSet<SizeSet> SizeSets { get; set; }
        
        
        

        public override int SaveChanges()
        {
            UpdateChangeTracker();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateChangeTracker();
            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }


        public void UpdateChangeTracker()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                Entry(entityReference).Property(x => x.ModifiedDate).IsModified = false;
                                Entry(entityReference).Property(x => x.ModifiedById).IsModified = false;
                                Entry(entityReference).Property(x => x.IsDeleted).IsModified = false;
                                Entry(entityReference).Property(x => x.IsDeletedDate).IsModified = false;
                                Entry(entityReference).Property(x => x.IsDeletedById).IsModified = false;
                                Entry(entityReference).Property(x => x.IsDeactived).IsModified = false;
                                Entry(entityReference).Property(x => x.IsDeactivedById).IsModified = false;
                                Entry(entityReference).Property(x => x.IsDeactivedDate).IsModified = false;
                                entityReference.CreatedDate = DateTime.Now;
                                break;

                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x => x.CreatedDate).IsModified = false;
                                Entry(entityReference).Property(x => x.CreatedById).IsModified = false;
                                entityReference.ModifiedDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }
        }
    }
}
