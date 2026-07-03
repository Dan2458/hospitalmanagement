using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.LabTests.Commands.CompleteLabTest;

public class CompleteLabTestHandler
    : IRequestHandler<CompleteLabTestCommand>
{
    private readonly ILabTestRepository _repository;

    public CompleteLabTestHandler(
        ILabTestRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(
        CompleteLabTestCommand request,
        CancellationToken cancellationToken)
    {
        var labTest = await _repository.GetByIdAsync(request.Id);

        if (labTest is null)
            throw new Exception("Lab test not found.");

        labTest.Complete(request.Result);

        await _repository.UpdateAsync(labTest);
    }
}