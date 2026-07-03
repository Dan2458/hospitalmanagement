using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.MedicalRecords.Queries.GetAllMedicalRecords;

public class GetAllMedicalRecordsHandler
    : IRequestHandler<GetAllMedicalRecordsQuery, List<MedicalRecord>>
{
    private readonly IMedicalRecordRepository _repository;

    public GetAllMedicalRecordsHandler(
        IMedicalRecordRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MedicalRecord>> Handle(
        GetAllMedicalRecordsQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}