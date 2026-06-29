using FluentValidation;
using MediatR;

namespace HospitalManagement.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        Console.WriteLine($"Pipeline executed for: {typeof(TRequest).Name}");
        Console.WriteLine($"Validators found: {_validators.Count()}");

        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var results = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = results
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .ToList();

            if (failures.Any())
            {
                Console.WriteLine("Validation failed!");

                foreach (var error in failures)
                {
                    Console.WriteLine($"{error.PropertyName}: {error.ErrorMessage}");
                }

                throw new ValidationException(failures);
            }
        }

        return await next();
    }
}