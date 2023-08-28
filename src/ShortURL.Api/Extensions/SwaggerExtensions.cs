using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ShortURL.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ShortURL Api",
                    Description = "An api for ShortURL",
                    Contact = new OpenApiContact
                    {
                        Name = "Creator Name",
                        Email = "Creator Email",
                        Url = new Uri("https://example.com")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
