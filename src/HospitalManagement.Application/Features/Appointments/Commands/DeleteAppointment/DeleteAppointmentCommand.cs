using MediatR;

namespace HospitalManagement.Application.Features.Appointments.Commands.DeleteAppointment;

public record DeleteAppointmentCommand(Guid Id) : IRequest<bool>;