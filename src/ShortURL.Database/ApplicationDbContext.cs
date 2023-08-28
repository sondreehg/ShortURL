using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShortURL.Abstractions.Common;
using ShortURL.Database.Abstractions;
using ShortURL.Database.Abstractions.Entities;
using ShortURL.Database.Abstractions.Extensions;
using System.Reflection;

namespace ShortURL.Database
{
    public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ShortenedURL> ShortenedURLs { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (EntityEntry<Auditable> entry in ChangeTracker.Entries<Auditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now.SetKindUtc();
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTime.Now.SetKindUtc();
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.HasDefaultSchema("app");
            base.OnModelCreating(builder);
        }
    }
}
