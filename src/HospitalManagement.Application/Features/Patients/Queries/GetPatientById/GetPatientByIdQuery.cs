using MediatR;

namespace HospitalManagement.Application.Features.Patients.Queries.GetPatientById;

public record GetPatientByIdQuery(Guid Id)
    : IRequest<PatientDetailResponse?>;