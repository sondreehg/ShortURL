using Microsoft.EntityFrameworkCore;
using ShortURL.Database.Abstractions;
using ShortURL.Database.Abstractions.Entities;
using ShortURL.Database.Abstractions.Repositories;

namespace ShortURL.Database.Repositories
{
    public class ShortenedURLRepository : IShortenedURLRepository
    {
        private readonly IApplicationDbContext _context;

        public ShortenedURLRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddShortenedURL(ShortenedURL shortenedURL, CancellationToken cancellationToken)
        {
            await _context.ShortenedURLs.AddAsync(shortenedURL);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<ShortenedURL?> GetShortenedURL(string shortenedURLId)
        {
            return await _context.ShortenedURLs.Where(x => x.Id == shortenedURLId).FirstOrDefaultAsync();
        }
    }
}
