using MediatR;

namespace HospitalManagement.Application.Features.Prescriptions.Commands.CreatePrescription;

public record CreatePrescriptionCommand(
    Guid PatientId,
    Guid DoctorId,
    Guid AppointmentId,
    string Medication,
    string Dosage,
    string Frequency,
    string Duration,
    string Instructions
) : IRequest<Guid>;