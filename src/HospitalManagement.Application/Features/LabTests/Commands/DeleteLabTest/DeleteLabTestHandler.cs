using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.LabTests.Commands.DeleteLabTest;

public class DeleteLabTestHandler
    : IRequestHandler<DeleteLabTestCommand>
{
    private readonly ILabTestRepository _repository;

    public DeleteLabTestHandler(
        ILabTestRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(
        DeleteLabTestCommand request,
        CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id);
    }
}