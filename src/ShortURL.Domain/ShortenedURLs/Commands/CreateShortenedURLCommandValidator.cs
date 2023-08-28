using FluentValidation;
using System.Text.RegularExpressions;

namespace ShortURL.Domain.ShortenedURLs.Commands.Validator
{
    public class CustomerValidator : AbstractValidator<CreateShortenedURLCommand>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.OriginalURL)
                .NotEmpty();

            RuleFor(x => x.OriginalURL)
                .Must(VerifyUrl)
                .When(x => string.IsNullOrEmpty(x.OriginalURL));
        }

        bool VerifyUrl(string url)
        {
            var pattern = @"[(http(s)?):\/\/(www\.)?a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)";
            var Rgx = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return Rgx.IsMatch(url);
        }
    }
}