using MediatR;

namespace HospitalManagement.Application.Features.Patients.Commands.CreatePatient;

public record CreatePatientCommand(
    string FirstName,
    string LastName,
    DateTime DateOfBirth
) : IRequest<Guid>;