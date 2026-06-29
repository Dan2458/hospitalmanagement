using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Patients.Commands.AdmitPatient;

public class AdmitPatientCommandHandler
    : IRequestHandler<AdmitPatientCommand, bool>
{
    private readonly IPatientRepository _repository;

    public AdmitPatientCommandHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        AdmitPatientCommand request,
        CancellationToken cancellationToken)
    {
        var patient = await _repository.GetByIdAsync(request.Id);

        if (patient is null)
            return false;

        patient.Admit();

        await _repository.UpdateAsync(patient);

        return true;
    }
}