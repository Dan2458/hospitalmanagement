using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Patients.Commands.AddBill;

public class AddBillCommandHandler
    : IRequestHandler<AddBillCommand, bool>
{
    private readonly IPatientRepository _repository;

    public AddBillCommandHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        AddBillCommand request,
        CancellationToken cancellationToken)
    {
        var patient = await _repository.GetByIdAsync(request.Id);

        if (patient is null)
            return false;

        patient.AddBill(request.Amount);

        await _repository.UpdateAsync(patient);

        return true;
    }
}