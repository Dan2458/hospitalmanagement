using MediatR;

namespace HospitalManagement.Application.Features.LabTests.Commands.CompleteLabTest;

public record CompleteLabTestCommand(
    Guid Id,
    string Result
) : IRequest;