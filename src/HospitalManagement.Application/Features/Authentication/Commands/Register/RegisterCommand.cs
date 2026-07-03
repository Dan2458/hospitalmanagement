// using MediatR;

// namespace HospitalManagement.Application.Features.Authentication.Commands.Register;

// public record RegisterCommand(
//     string FirstName,
//     string LastName,
//     string Email,
//     string Password
// ) : IRequest<bool>;


using MediatR;

namespace HospitalManagement.Application.Features.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string Role
) : IRequest<bool>;