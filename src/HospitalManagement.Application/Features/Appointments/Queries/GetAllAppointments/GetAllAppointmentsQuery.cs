using MediatR;

namespace HospitalManagement.Application.Features.Appointments.Queries.GetAllAppointments;

public record GetAllAppointmentsQuery()
    : IRequest<List<AppointmentResponse>>;