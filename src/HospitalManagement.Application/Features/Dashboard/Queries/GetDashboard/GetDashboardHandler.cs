using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Dashboard.Queries.GetDashboard;

public class GetDashboardHandler
    : IRequestHandler<GetDashboardQuery, DashboardDto>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMedicalRecordRepository _medicalRecordRepository;

    public GetDashboardHandler(
        IPatientRepository patientRepository,
        IDoctorRepository doctorRepository,
        IAppointmentRepository appointmentRepository,
        IMedicalRecordRepository medicalRecordRepository)
    {
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
        _appointmentRepository = appointmentRepository;
        _medicalRecordRepository = medicalRecordRepository;
    }

    public async Task<DashboardDto> Handle(
        GetDashboardQuery request,
        CancellationToken cancellationToken)
    {
        return new DashboardDto
        {
            TotalPatients =
                await _patientRepository.CountAsync(),

            TotalDoctors =
                await _doctorRepository.CountAsync(),

            TotalAppointments =
                await _appointmentRepository.CountAsync(),

            CompletedAppointments =
                await _appointmentRepository.CountCompletedAsync(),

            TotalMedicalRecords =
                await _medicalRecordRepository.CountAsync()
        };
    }
}