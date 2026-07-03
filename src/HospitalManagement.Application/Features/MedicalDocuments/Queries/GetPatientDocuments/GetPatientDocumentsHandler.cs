using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.MedicalDocuments.Queries.GetPatientDocuments;

public class GetPatientDocumentsHandler
    : IRequestHandler<GetPatientDocumentsQuery, List<MedicalDocumentDto>>
{
    private readonly IMedicalDocumentRepository _repository;

    public GetPatientDocumentsHandler(
        IMedicalDocumentRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MedicalDocumentDto>> Handle(
        GetPatientDocumentsQuery request,
        CancellationToken cancellationToken)
    {
        var docs = await _repository.GetPatientDocumentsAsync(request.PatientId);

        return docs.Select(x => new MedicalDocumentDto
        {
            Id = x.Id,
            FileName = x.FileName,
            OriginalFileName = x.OriginalFileName,
            ContentType = x.ContentType,
            FileSize = x.FileSize,
            UploadedAt = x.UploadedAt
        }).ToList();
    }
}