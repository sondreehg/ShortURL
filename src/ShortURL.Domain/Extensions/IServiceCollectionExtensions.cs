using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShortURL.Domain.Behavior;
using System.Reflection;

namespace ShortURL.Domain.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            services.AddMediatR(c =>
            {
                c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
