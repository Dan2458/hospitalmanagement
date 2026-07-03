using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.MedicalRecords.Queries.GetMedicalRecordById;

public class GetMedicalRecordByIdHandler
    : IRequestHandler<GetMedicalRecordByIdQuery, MedicalRecord?>
{
    private readonly IMedicalRecordRepository _repository;

    public GetMedicalRecordByIdHandler(IMedicalRecordRepository repository)
    {
        _repository = repository;
    }

    public async Task<MedicalRecord?> Handle(
        GetMedicalRecordByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}