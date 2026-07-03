using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Appointments.Queries.GetAllAppointments;

public class GetAllAppointmentsHandler
    : IRequestHandler<GetAllAppointmentsQuery, List<AppointmentResponse>>
{
    private readonly IAppointmentRepository _repository;

    public GetAllAppointmentsHandler(
        IAppointmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<AppointmentResponse>> Handle(
        GetAllAppointmentsQuery request,
        CancellationToken cancellationToken)
    {
        var appointments = await _repository.GetAllAsync();

        return appointments.Select(a => new AppointmentResponse
        {
            Id = a.Id,
            PatientName = $"{a.Patient.FirstName} {a.Patient.LastName}",
            DoctorName = $"{a.Doctor.FirstName} {a.Doctor.LastName}",
            AppointmentDate = a.AppointmentDate,
            Reason = a.Reason,
            IsCompleted = a.IsCompleted
        }).ToList();
    }
}