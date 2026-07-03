// // using FluentValidation;

// // namespace HospitalManagement.Application.Features.Authentication.Commands.Register;

// // public class RegisterValidator : AbstractValidator<RegisterCommand>
// // {
// //     public RegisterValidator()
// //     {
// //         RuleFor(x => x.FirstName)
// //             .NotEmpty()
// //             .MaximumLength(100);

// //         RuleFor(x => x.LastName)
// //             .NotEmpty()
// //             .MaximumLength(100);

// //         RuleFor(x => x.Email)
// //             .NotEmpty()
// //             .EmailAddress();

// //         RuleFor(x => x.Password)
// //             .NotEmpty()
// //             .MinimumLength(8)
// //             .Matches("[A-Z]")
// //             .WithMessage("Password must contain at least one uppercase letter.")
// //             .Matches("[a-z]")
// //             .WithMessage("Password must contain at least one lowercase letter.")
// //             .Matches("[0-9]")
// //             .WithMessage("Password must contain at least one number.");
// //     }
// // }



// using FluentValidation;

// namespace HospitalManagement.Application.Features.Authentication.Commands.Register;

// public class RegisterValidator : AbstractValidator<RegisterCommand>
// {
//     public RegisterValidator()
//     {
//         RuleFor(x => x.FirstName)
//             .NotEmpty()
//             .MaximumLength(100);

//         RuleFor(x => x.LastName)
//             .NotEmpty()
//             .MaximumLength(100);

//         RuleFor(x => x.Email)
//             .NotEmpty()
//             .EmailAddress();

//         RuleFor(x => x.Password)
//             .NotEmpty()
//             .MinimumLength(8)
//             .Matches("[A-Z]")
//             .WithMessage("Password must contain at least one uppercase letter.")
//             .Matches("[a-z]")
//             .WithMessage("Password must contain at least one lowercase letter.")
//             .Matches("[0-9]")
//             .WithMessage("Password must contain at least one number.");

//         RuleFor(x => x.Role)
//             .NotEmpty()
//             .WithMessage("Role is required.");
//     }
// }



using HospitalManagement.Application.Interfaces.Identity;
using MediatR;

namespace HospitalManagement.Application.Features.Authentication.Commands.Register;

public class RegisterHandler : IRequestHandler<RegisterCommand, bool>
{
    private readonly IIdentityService _identityService;

    public RegisterHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<bool> Handle(
        RegisterCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _identityService.RegisterAsync(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password,
            request.Role);

        if (!result.Succeeded)
        {
            throw new Exception(string.Join(", ", result.Errors));
        }

        return true;
    }
}