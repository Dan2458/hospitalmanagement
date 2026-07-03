using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.LabTests.Queries.GetAllLabTests;

public class GetAllLabTestsHandler
    : IRequestHandler<GetAllLabTestsQuery, List<LabTest>>
{
    private readonly ILabTestRepository _repository;

    public GetAllLabTestsHandler(ILabTestRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<LabTest>> Handle(
        GetAllLabTestsQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}