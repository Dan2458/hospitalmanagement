using MediatR;

namespace HospitalManagement.Application.Features.MedicalRecords.Commands.UpdateMedicalRecord;

public record UpdateMedicalRecordCommand(
    Guid Id,
    string Diagnosis,
    string Symptoms,
    string Treatment,
    string Notes
) : IRequest;