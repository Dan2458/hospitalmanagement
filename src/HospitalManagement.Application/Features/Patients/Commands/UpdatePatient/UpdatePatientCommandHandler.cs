using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Patients.Commands.UpdatePatient;

public class UpdatePatientCommandHandler
    : IRequestHandler<UpdatePatientCommand, bool>
{
    private readonly IPatientRepository _repository;

    public UpdatePatientCommandHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        UpdatePatientCommand request,
        CancellationToken cancellationToken)
    {
        var patient = await _repository.GetByIdAsync(request.Id);

        if (patient is null)
            return false;

        patient.UpdateInformation(
            request.FirstName,
            request.LastName,
            request.DateOfBirth);

        await _repository.UpdateAsync(patient);

        return true;
    }
}