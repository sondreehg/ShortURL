using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShortURL.Database.Abstractions;
using ShortURL.Database.Abstractions.Repositories;
using ShortURL.Database;
using ShortURL.Database.Repositories;

namespace ShortURL.Database.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(o => o.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddScoped<IShortenedURLRepository, ShortenedURLRepository>();

            return services;
        }
    }
}
