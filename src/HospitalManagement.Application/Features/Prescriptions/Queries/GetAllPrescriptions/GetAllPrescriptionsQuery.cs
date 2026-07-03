using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.Prescriptions.Queries.GetAllPrescriptions;

public class GetAllPrescriptionsHandler
    : IRequestHandler<GetAllPrescriptionsQuery, List<Prescription>>
{
    private readonly IPrescriptionRepository _repository;

    public GetAllPrescriptionsHandler(
        IPrescriptionRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Prescription>> Handle(
        GetAllPrescriptionsQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}