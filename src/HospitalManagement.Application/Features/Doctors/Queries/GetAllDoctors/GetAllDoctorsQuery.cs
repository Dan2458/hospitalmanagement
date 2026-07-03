using MediatR;

namespace HospitalManagement.Application.Features.Doctors.Queries.GetAllDoctors;

public record GetAllDoctorsQuery : IRequest<List<DoctorResponse>>;