using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Prescriptions.Commands.UpdatePrescription;

public class UpdatePrescriptionHandler
    : IRequestHandler<UpdatePrescriptionCommand>
{
    private readonly IPrescriptionRepository _repository;

    public UpdatePrescriptionHandler(
        IPrescriptionRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(
        UpdatePrescriptionCommand request,
        CancellationToken cancellationToken)
    {
        var prescription = await _repository.GetByIdAsync(request.Id);

        if (prescription is null)
            throw new Exception("Prescription not found.");

        prescription.Update(
            request.Medication,
            request.Dosage,
            request.Frequency,
            request.Duration,
            request.Instructions);

        await _repository.UpdateAsync(prescription);
    }
}