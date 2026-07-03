using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.MedicalRecords.Commands.CreateMedicalRecord;

public class CreateMedicalRecordHandler
    : IRequestHandler<CreateMedicalRecordCommand, Guid>
{
    private readonly IMedicalRecordRepository _medicalRecordRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IAppointmentRepository _appointmentRepository;

    public CreateMedicalRecordHandler(
        IMedicalRecordRepository medicalRecordRepository,
        IPatientRepository patientRepository,
        IDoctorRepository doctorRepository,
        IAppointmentRepository appointmentRepository)
    {
        _medicalRecordRepository = medicalRecordRepository;
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
        _appointmentRepository = appointmentRepository;
    }

    public async Task<Guid> Handle(
        CreateMedicalRecordCommand request,
        CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetByIdAsync(request.PatientId);

        if (patient is null)
            throw new Exception("Patient not found.");

        var doctor = await _doctorRepository.GetByIdAsync(request.DoctorId);

        if (doctor is null)
            throw new Exception("Doctor not found.");

        var appointment = await _appointmentRepository.GetByIdAsync(request.AppointmentId);

        if (appointment is null)
            throw new Exception("Appointment not found.");

        var record = new MedicalRecord(
            request.AppointmentId,
            request.PatientId,
            request.DoctorId,
            request.Diagnosis,
            request.Symptoms,
            request.Treatment,
            request.Notes);

        await _medicalRecordRepository.AddAsync(record);

        return record.Id;
    }
}