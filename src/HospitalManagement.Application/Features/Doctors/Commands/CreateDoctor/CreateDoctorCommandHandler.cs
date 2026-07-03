using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.Doctors.Commands.CreateDoctor;

public class CreateDoctorCommandHandler
    : IRequestHandler<CreateDoctorCommand, Guid>
{
    private readonly IDoctorRepository _repository;

    public CreateDoctorCommandHandler(IDoctorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(
        CreateDoctorCommand request,
        CancellationToken cancellationToken)
    {
        var doctor = new Doctor(
            request.FirstName,
            request.LastName,
            request.Email,
            request.PhoneNumber,
            request.Specialty);

        await _repository.AddAsync(doctor);

        return doctor.Id;
    }
}