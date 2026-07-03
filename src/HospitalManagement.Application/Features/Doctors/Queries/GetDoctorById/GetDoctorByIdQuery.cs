using MediatR;

namespace HospitalManagement.Application.Features.Doctors.Queries.GetDoctorById;

public record GetDoctorByIdQuery(Guid Id)
    : IRequest<DoctorDetailResponse?>;