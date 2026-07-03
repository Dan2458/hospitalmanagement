using MediatR;

namespace HospitalManagement.Application.Features.MedicalRecords.Commands.CreateMedicalRecord;

public record CreateMedicalRecordCommand(
    Guid AppointmentId,
    Guid PatientId,
    Guid DoctorId,
    string Diagnosis,
    string Symptoms,
    string Treatment,
    string Notes
) : IRequest<Guid>;