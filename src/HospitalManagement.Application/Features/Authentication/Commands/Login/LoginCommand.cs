using MediatR;

namespace HospitalManagement.Application.Features.Authentication.Commands.Login;

public record LoginCommand(
    string Email,
    string Password
) : IRequest<string?>;