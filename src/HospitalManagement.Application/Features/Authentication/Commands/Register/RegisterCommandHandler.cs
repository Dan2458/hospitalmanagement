// using HospitalManagement.Application.Interfaces.Identity;
// using MediatR;

// namespace HospitalManagement.Application.Features.Authentication.Commands.Register;

// public class RegisterCommandHandler
//     : IRequestHandler<RegisterCommand, bool>
// {
//     private readonly IIdentityService _identityService;

//     public RegisterCommandHandler(IIdentityService identityService)
//     {
//         _identityService = identityService;
//     }

//     public async Task<bool> Handle(
//         RegisterCommand request,
//         CancellationToken cancellationToken)
//     {
//         var result = await _identityService.RegisterAsync(
//             request.FirstName,
//             request.LastName,
//             request.Email,
//             request.Password);

//         return result.Succeeded;
//     }
// }



using HospitalManagement.Application.Interfaces.Identity;
using MediatR;

namespace HospitalManagement.Application.Features.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
{
    private readonly IIdentityService _identityService;

    public RegisterCommandHandler(IIdentityService identityService)
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