using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.Prescriptions.Commands.CreatePrescription;

public class CreatePrescriptionHandler
    : IRequestHandler<CreatePrescriptionCommand, Guid>
{
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IAppointmentRepository _appointmentRepository;

    public CreatePrescriptionHandler(
        IPrescriptionRepository prescriptionRepository,
        IPatientRepository patientRepository,
        IDoctorRepository doctorRepository,
        IAppointmentRepository appointmentRepository)
    {
        _prescriptionRepository = prescriptionRepository;
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
        _appointmentRepository = appointmentRepository;
    }

    public async Task<Guid> Handle(
        CreatePrescriptionCommand request,
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

        var prescription = new Prescription(
            request.PatientId,
            request.DoctorId,
            request.AppointmentId,
            request.Medication,
            request.Dosage,
            request.Frequency,
            request.Duration,
            request.Instructions);

        await _prescriptionRepository.AddAsync(prescription);

        return prescription.Id;
    }
}