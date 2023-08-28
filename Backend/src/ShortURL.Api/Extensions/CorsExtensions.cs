namespace ShortURL.Api.Extensions
{
    public static class CorsInjection
    {
        /// <summary>
        /// Adds custom CORS schemes to an IServiceCollection
        /// </summary>
        /// <param name="services"></param>
        public static void AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
                options.AddPolicy(name: "DevPolicy", builder =>
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
        }
    }
}
