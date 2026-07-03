using MediatR;

namespace HospitalManagement.Application.Features.Doctors.Commands.UpdateDoctor;

public record UpdateDoctorCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Specialty
) : IRequest<bool>;