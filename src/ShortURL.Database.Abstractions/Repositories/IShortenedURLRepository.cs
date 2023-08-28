using ShortURL.Database.Abstractions.Entities;

namespace ShortURL.Database.Abstractions.Repositories
{
    public interface IShortenedURLRepository
    {
        public Task<ShortenedURL?> GetShortenedURL(string shortenedURLId);
        public Task AddShortenedURL(ShortenedURL shortenedURL, CancellationToken cancellationToken);
    }
}
