using MediatR;

namespace HospitalManagement.Application.Features.Appointments.Queries.GetAppointmentById;

public record GetAppointmentByIdQuery(Guid Id)
    : IRequest<AppointmentDetailResponse?>;