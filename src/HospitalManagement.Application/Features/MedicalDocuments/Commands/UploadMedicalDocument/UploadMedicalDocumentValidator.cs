using HospitalManagement.Application.Interfaces;
using HospitalManagement.Application.Interfaces.FileStorage;
using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.MedicalDocuments.Commands.UploadMedicalDocument;

public class UploadMedicalDocumentHandler
    : IRequestHandler<UploadMedicalDocumentCommand, Guid>
{
    private readonly IMedicalDocumentRepository _repository;
    private readonly IFileStorageService _fileStorage;

    public UploadMedicalDocumentHandler(
        IMedicalDocumentRepository repository,
        IFileStorageService fileStorage)
    {
        _repository = repository;
        _fileStorage = fileStorage;
    }

    public async Task<Guid> Handle(
        UploadMedicalDocumentCommand request,
        CancellationToken cancellationToken)
    {
        var savedFile = await _fileStorage.UploadAsync(
            request.FileStream,
            request.FileName,
            request.ContentType);

        var document = new MedicalDocument(
            request.PatientId,
            savedFile,
            request.FileName,
            request.ContentType,
            request.FileSize,
            savedFile);

        await _repository.AddAsync(document);

        await _repository.SaveChangesAsync();

        return document.Id;
    }
}