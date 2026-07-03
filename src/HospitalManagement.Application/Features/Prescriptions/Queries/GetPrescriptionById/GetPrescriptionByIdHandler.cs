using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.Prescriptions.Queries.GetPrescriptionById;

public class GetPrescriptionByIdHandler
    : IRequestHandler<GetPrescriptionByIdQuery, Prescription?>
{
    private readonly IPrescriptionRepository _repository;

    public GetPrescriptionByIdHandler(
        IPrescriptionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Prescription?> Handle(
        GetPrescriptionByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}