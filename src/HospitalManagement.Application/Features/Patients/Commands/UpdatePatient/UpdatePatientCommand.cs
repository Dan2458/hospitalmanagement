using MediatR;

namespace HospitalManagement.Application.Features.Patients.Commands.UpdatePatient;

public record UpdatePatientCommand(
    Guid Id,
    string FirstName,
    string LastName,
    DateTime DateOfBirth
) : IRequest<bool>;