using Microsoft.EntityFrameworkCore;
using ShortURL.Database.Abstractions.Entities;

namespace ShortURL.Database.Abstractions
{
    public interface IApplicationDbContext
    {
        public DbSet<ShortenedURL> ShortenedURLs { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
