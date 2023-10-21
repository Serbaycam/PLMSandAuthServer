using Microsoft.EntityFrameworkCore;
using PLMS.Core.Entity;
using System.Reflection;

namespace PLMS.Repository.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }

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
                                entityReference.CreatedDate = DateTime.Now; break;

                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x => x.CreatedDate).IsModified = false;
                                entityReference.ModifiedDate = DateTime.Now; break;
                            }
                    }
                }
            }
        }
    }
}
