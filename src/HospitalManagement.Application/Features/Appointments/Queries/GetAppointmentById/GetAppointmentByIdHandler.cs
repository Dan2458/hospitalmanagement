using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Appointments.Queries.GetAppointmentById;

public class GetAppointmentByIdHandler
    : IRequestHandler<GetAppointmentByIdQuery, AppointmentDetailResponse?>
{
    private readonly IAppointmentRepository _repository;

    public GetAppointmentByIdHandler(IAppointmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<AppointmentDetailResponse?> Handle(
        GetAppointmentByIdQuery request,
        CancellationToken cancellationToken)
    {
        var appointment = await _repository.GetByIdAsync(request.Id);

        if (appointment is null)
            return null;

        return new AppointmentDetailResponse
        {
            Id = appointment.Id,
            PatientName = $"{appointment.Patient.FirstName} {appointment.Patient.LastName}",
            DoctorName = $"{appointment.Doctor.FirstName} {appointment.Doctor.LastName}",
            AppointmentDate = appointment.AppointmentDate,
            Reason = appointment.Reason,
            IsCompleted = appointment.IsCompleted
        };
    }
}