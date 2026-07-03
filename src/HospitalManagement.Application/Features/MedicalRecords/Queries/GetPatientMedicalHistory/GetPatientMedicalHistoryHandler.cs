using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.MedicalRecords.Queries.GetPatientMedicalHistory;

public class GetPatientMedicalHistoryHandler
    : IRequestHandler<GetPatientMedicalHistoryQuery, List<MedicalRecord>>
{
    private readonly IMedicalRecordRepository _repository;

    public GetPatientMedicalHistoryHandler(
        IMedicalRecordRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MedicalRecord>> Handle(
        GetPatientMedicalHistoryQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetPatientHistoryAsync(request.PatientId);
    }
}