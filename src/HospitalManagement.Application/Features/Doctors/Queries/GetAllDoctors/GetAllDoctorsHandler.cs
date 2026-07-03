using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Doctors.Queries.GetAllDoctors;

public class GetAllDoctorsHandler
    : IRequestHandler<GetAllDoctorsQuery, List<DoctorResponse>>
{
    private readonly IDoctorRepository _repository;

    public GetAllDoctorsHandler(IDoctorRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<DoctorResponse>> Handle(
        GetAllDoctorsQuery request,
        CancellationToken cancellationToken)
    {
        var doctors = await _repository.GetAllAsync();

        return doctors.Select(x => new DoctorResponse
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Email = x.Email,
            PhoneNumber = x.PhoneNumber,
            Specialty = x.Specialty
        }).ToList();
    }
}