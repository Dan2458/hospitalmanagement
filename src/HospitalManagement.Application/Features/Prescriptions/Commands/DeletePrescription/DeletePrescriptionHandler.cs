using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Prescriptions.Commands.DeletePrescription;

public class DeletePrescriptionHandler
    : IRequestHandler<DeletePrescriptionCommand>
{
    private readonly IPrescriptionRepository _repository;

    public DeletePrescriptionHandler(
        IPrescriptionRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(
        DeletePrescriptionCommand request,
        CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id);
    }
}