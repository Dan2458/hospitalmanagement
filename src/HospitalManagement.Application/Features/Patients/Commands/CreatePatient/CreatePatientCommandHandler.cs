using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.Patients.Commands.CreatePatient;

public class CreatePatientCommandHandler
    : IRequestHandler<CreatePatientCommand, Guid>
{
    private readonly IPatientRepository _repository;

    public CreatePatientCommandHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(
        CreatePatientCommand request,
        CancellationToken cancellationToken)
    {
        var patient = new Patient(
            request.FirstName,
            request.LastName,
            request.DateOfBirth);

        await _repository.AddAsync(patient);

        return patient.Id;
    }
}