using Microsoft.AspNetCore.Mvc;
using ShortURL.Domain.ShortenedURLs.Commands;
using ShortURL.Domain.ShortenedURLs.Queries;

namespace ShortURL.Api.Controllers
{
    [ApiController]
    [Route("api/v1/shorten")]
    public class ShortenedURLController : BaseController
    {
        private readonly ILogger<ShortenedURLController> _logger;

        public ShortenedURLController(ILogger<ShortenedURLController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets a a full url based on a short url id.
        /// </summary>
        /// <param name="id">A short url id</param>
        /// <returns>A full length url</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetShortenedURL(string id)
        {
            var shortenedURL = await Mediator.Send(new GetShortenedURLQuery(id));
            if (shortenedURL != null) 
                return Ok(shortenedURL.Content);

            return NotFound();
        }    
     
        /// <summary>
        /// Creates a shortened url.
        /// </summary>
        /// <param name="originalURL">The original url</param>
        /// <returns>The id of created short url.</returns>
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> CreateShortenedURL([FromForm]string originalURL)
        {
            var shortenedURL = await Mediator.Send(new CreateShortenedURLCommand {OriginalURL = originalURL});
            return Ok(shortenedURL);
        }
    }
}
