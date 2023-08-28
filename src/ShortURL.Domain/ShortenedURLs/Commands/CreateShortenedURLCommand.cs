using MediatR;
using shortid;
using shortid.Configuration;
using ShortURL.Database.Abstractions.Entities;
using ShortURL.Database.Abstractions.Repositories;

namespace ShortURL.Domain.ShortenedURLs.Commands
{
    public class CreateShortenedURLCommand : IRequest<string>
    {
        public string OriginalURL { get; set; }
    }

    public class CreateShortenedURLHandler : IRequestHandler<CreateShortenedURLCommand, string>
    {
        private readonly IShortenedURLRepository _shortenedURLRepository;

        public CreateShortenedURLHandler(IShortenedURLRepository shortenedURLRepository)
        {
            _shortenedURLRepository = shortenedURLRepository;
        }

        public async Task<string> Handle(CreateShortenedURLCommand command, CancellationToken cancellationToken)
        {
            var shortIdOptions = new GenerationOptions(useNumbers: true, length: 10);
            ShortenedURL shortenedURL = new()
            {
                Content = command.OriginalURL,
                Id = ShortId.Generate(shortIdOptions)
            };
            await _shortenedURLRepository.AddShortenedURL(shortenedURL, cancellationToken);
            return shortenedURL.Id.ToString();
        }
    }
}
