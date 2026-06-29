using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Patients.Queries.GetPatientById;

public class GetPatientByIdHandler
    : IRequestHandler<GetPatientByIdQuery, PatientDetailResponse?>
{
    private readonly IPatientRepository _repository;

    public GetPatientByIdHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<PatientDetailResponse?> Handle(
        GetPatientByIdQuery request,
        CancellationToken cancellationToken)
    {
        var patient = await _repository.GetByIdAsync(request.Id);

        if (patient is null)
            return null;

        return new PatientDetailResponse
        {
            Id = patient.Id,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            DateOfBirth = patient.DateOfBirth,
            IsAdmitted = patient.IsAdmitted,
            OutstandingBalance = patient.OutstandingBalance,
            Age = patient.GetAge()
        };
    }
}