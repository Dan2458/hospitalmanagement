using MediatR;

namespace HospitalManagement.Application.Features.Doctors.Commands.DeleteDoctor;

public record DeleteDoctorCommand(Guid Id) : IRequest<bool>;