using MediatR;

namespace HospitalManagement.Application.Features.Appointments.Commands.CreateAppointment;

public record CreateAppointmentCommand(
    Guid PatientId,
    Guid DoctorId,
    DateTime AppointmentDate,
    string Reason
) : IRequest<Guid>;