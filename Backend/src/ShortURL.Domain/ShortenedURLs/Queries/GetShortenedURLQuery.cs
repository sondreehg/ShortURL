using MediatR;
using ShortURL.Database.Abstractions.Entities;
using ShortURL.Database.Abstractions.Repositories;

namespace ShortURL.Domain.ShortenedURLs.Queries
{
    public class GetShortenedURLQuery : IRequest<ShortenedURL?>
    {
        public string Id { get; set; }
        public GetShortenedURLQuery(string id)
        {
            Id = id;
        }
    }

    public class GetShortenedURLByIdHandler : IRequestHandler<GetShortenedURLQuery, ShortenedURL?>
    {
        private readonly IShortenedURLRepository _shortenedURLRepository;

        public GetShortenedURLByIdHandler(IShortenedURLRepository shortenedURLRepository)
        {
            _shortenedURLRepository = shortenedURLRepository;
        }

        public async Task<ShortenedURL?> Handle(GetShortenedURLQuery query, CancellationToken cancellationToken)
        {
            return await _shortenedURLRepository.GetShortenedURL(query.Id);
        }
    }
}
