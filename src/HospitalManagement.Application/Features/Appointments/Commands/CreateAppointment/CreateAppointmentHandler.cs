using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.Appointments.Commands.CreateAppointment;

public class CreateAppointmentHandler
    : IRequestHandler<CreateAppointmentCommand, Guid>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;

    public CreateAppointmentHandler(
        IAppointmentRepository appointmentRepository,
        IPatientRepository patientRepository,
        IDoctorRepository doctorRepository)
    {
        _appointmentRepository = appointmentRepository;
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
    }

    public async Task<Guid> Handle(
    CreateAppointmentCommand request,
    CancellationToken cancellationToken)
{
    var patient = await _patientRepository.GetByIdAsync(request.PatientId);

    if (patient is null)
        throw new Exception("Patient not found.");

    var doctor = await _doctorRepository.GetByIdAsync(request.DoctorId);

    if (doctor is null)
        throw new Exception("Doctor not found.");

    // Prevent double booking
    var exists = await _appointmentRepository.ExistsAsync(
        request.DoctorId,
        request.AppointmentDate);

    if (exists)
        throw new Exception("Doctor already has an appointment at this time.");

    var appointment = new Appointment(
        request.PatientId,
        request.DoctorId,
        request.AppointmentDate,
        request.Reason);

    await _appointmentRepository.AddAsync(appointment);

    return appointment.Id;
}
}