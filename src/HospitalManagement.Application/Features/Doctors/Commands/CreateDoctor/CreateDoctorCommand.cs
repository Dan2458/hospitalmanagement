using MediatR;

namespace HospitalManagement.Application.Features.Doctors.Commands.CreateDoctor;

public record CreateDoctorCommand(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Specialty
) : IRequest<Guid>;