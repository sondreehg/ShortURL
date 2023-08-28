
using ShortURL.Abstractions.Common;

namespace ShortURL.Database.Abstractions.Entities
{
    public class ShortenedURL : Auditable
    {
        public string Id { get; set; }
        public string Content { get; set; }
    }
}
