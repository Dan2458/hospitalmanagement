using MediatR;

namespace HospitalManagement.Application.Features.MedicalDocuments.Commands.UploadMedicalDocument;

public record UploadMedicalDocumentCommand(
    Guid PatientId,
    Stream FileStream,
    string FileName,
    string ContentType,
    long FileSize
) : IRequest<Guid>;