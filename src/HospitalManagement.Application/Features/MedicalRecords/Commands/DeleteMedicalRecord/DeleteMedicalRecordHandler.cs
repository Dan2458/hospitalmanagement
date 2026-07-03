using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.MedicalRecords.Commands.DeleteMedicalRecord;

public class DeleteMedicalRecordHandler
    : IRequestHandler<DeleteMedicalRecordCommand>
{
    private readonly IMedicalRecordRepository _repository;

    public DeleteMedicalRecordHandler(
        IMedicalRecordRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(
        DeleteMedicalRecordCommand request,
        CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id);
    }
}