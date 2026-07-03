using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.MedicalRecords.Commands.UpdateMedicalRecord;

public class UpdateMedicalRecordHandler
    : IRequestHandler<UpdateMedicalRecordCommand>
{
    private readonly IMedicalRecordRepository _repository;

    public UpdateMedicalRecordHandler(
        IMedicalRecordRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(
        UpdateMedicalRecordCommand request,
        CancellationToken cancellationToken)
    {
        var record = await _repository.GetByIdAsync(request.Id);

        if (record is null)
            throw new Exception("Medical record not found.");

        record.Update(
            request.Diagnosis,
            request.Symptoms,
            request.Treatment,
            request.Notes);

        await _repository.UpdateAsync(record);
    }
}