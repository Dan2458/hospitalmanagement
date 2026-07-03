using MediatR;

namespace HospitalManagement.Application.Features.Appointments.Commands.CompleteAppointment;

public record CompleteAppointmentCommand(Guid Id) : IRequest<bool>;