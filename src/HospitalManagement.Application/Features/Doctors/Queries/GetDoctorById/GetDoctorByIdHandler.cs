using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Doctors.Queries.GetDoctorById;

public class GetDoctorByIdHandler
    : IRequestHandler<GetDoctorByIdQuery, DoctorDetailResponse?>
{
    private readonly IDoctorRepository _repository;

    public GetDoctorByIdHandler(IDoctorRepository repository)
    {
        _repository = repository;
    }

    public async Task<DoctorDetailResponse?> Handle(
        GetDoctorByIdQuery request,
        CancellationToken cancellationToken)
    {
        var doctor = await _repository.GetByIdAsync(request.Id);

        if (doctor is null)
            return null;

        return new DoctorDetailResponse
        {
            Id = doctor.Id,
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Email = doctor.Email,
            PhoneNumber = doctor.PhoneNumber,
            Specialty = doctor.Specialty
        };
    }
}