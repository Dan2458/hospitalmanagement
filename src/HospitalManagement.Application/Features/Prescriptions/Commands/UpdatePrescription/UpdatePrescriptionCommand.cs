using MediatR;

namespace HospitalManagement.Application.Features.Prescriptions.Commands.UpdatePrescription;

public record UpdatePrescriptionCommand(
    Guid Id,
    string Medication,
    string Dosage,
    string Frequency,
    string Duration,
    string Instructions
) : IRequest;