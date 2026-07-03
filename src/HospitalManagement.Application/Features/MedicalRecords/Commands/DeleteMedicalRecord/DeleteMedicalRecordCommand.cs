using MediatR;

namespace HospitalManagement.Application.Features.MedicalRecords.Commands.DeleteMedicalRecord;

public record DeleteMedicalRecordCommand(Guid Id) : IRequest;