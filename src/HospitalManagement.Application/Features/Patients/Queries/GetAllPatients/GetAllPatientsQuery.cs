using MediatR;

namespace HospitalManagement.Application.Features.Patients.Queries.GetAllPatients;

public record GetAllPatientsQuery()
    : IRequest<List<PatientResponse>>;