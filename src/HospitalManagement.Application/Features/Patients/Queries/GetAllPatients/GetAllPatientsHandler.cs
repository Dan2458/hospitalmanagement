using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Patients.Queries.GetAllPatients;

public class GetAllPatientsHandler
    : IRequestHandler<GetAllPatientsQuery, List<PatientResponse>>
{
    private readonly IPatientRepository _repository;

    public GetAllPatientsHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<PatientResponse>> Handle(
        GetAllPatientsQuery request,
        CancellationToken cancellationToken)
    {
        var patients = await _repository.GetAllAsync();

        return patients.Select(patient => new PatientResponse
        {
            Id = patient.Id,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            IsAdmitted = patient.IsAdmitted,
            OutstandingBalance = patient.OutstandingBalance,
            Age = patient.GetAge()
        }).ToList();
    }
}