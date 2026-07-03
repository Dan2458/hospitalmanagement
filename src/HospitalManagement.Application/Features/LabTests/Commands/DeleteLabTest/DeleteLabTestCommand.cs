using MediatR;

namespace HospitalManagement.Application.Features.LabTests.Commands.DeleteLabTest;

public record DeleteLabTestCommand(Guid Id) : IRequest;