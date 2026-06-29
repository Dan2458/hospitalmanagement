using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Patients.Commands.DischargePatient;

public class DischargePatientCommandHandler
    : IRequestHandler<DischargePatientCommand, bool>
{
    private readonly IPatientRepository _repository;

    public DischargePatientCommandHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DischargePatientCommand request,
        CancellationToken cancellationToken)
    {
        var patient = await _repository.GetByIdAsync(request.Id);

        if (patient is null)
            return false;

        patient.Discharge();

        await _repository.UpdateAsync(patient);

        return true;
    }
}