using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Patients.Commands.PayBill;

public class PayBillCommandHandler
    : IRequestHandler<PayBillCommand, bool>
{
    private readonly IPatientRepository _repository;

    public PayBillCommandHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        PayBillCommand request,
        CancellationToken cancellationToken)
    {
        var patient = await _repository.GetByIdAsync(request.Id);

        if (patient is null)
            return false;

        patient.PayBill(request.Amount);

        await _repository.UpdateAsync(patient);

        return true;
    }
}