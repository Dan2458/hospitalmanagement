using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.LabTests.Queries.GetLabTestById;

public class GetLabTestByIdHandler
    : IRequestHandler<GetLabTestByIdQuery, LabTest?>
{
    private readonly ILabTestRepository _repository;

    public GetLabTestByIdHandler(ILabTestRepository repository)
    {
        _repository = repository;
    }

    public async Task<LabTest?> Handle(
        GetLabTestByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}