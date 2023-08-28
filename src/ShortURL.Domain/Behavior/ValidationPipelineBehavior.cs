using FluentValidation;
using MediatR;

namespace ShortURL.Domain.Behavior
{
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidationPipelineBehavior(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            IValidator<TRequest> _validator = null!;

            try
            {
                _validator = (IValidator<TRequest>)_serviceProvider.GetService(typeof(IValidator<TRequest>));
            }catch(Exception){ }
            
            if(_validator is not null)
            {
                var validationResult = await _validator.ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }
            }

            return await next();
        }
    }
}
