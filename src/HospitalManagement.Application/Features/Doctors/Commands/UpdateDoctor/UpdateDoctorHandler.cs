using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Doctors.Commands.UpdateDoctor;

public class UpdateDoctorHandler
    : IRequestHandler<UpdateDoctorCommand, bool>
{
    private readonly IDoctorRepository _repository;

    public UpdateDoctorHandler(IDoctorRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        UpdateDoctorCommand request,
        CancellationToken cancellationToken)
    {
        var doctor = await _repository.GetByIdAsync(request.Id);

        if (doctor is null)
            return false;

        doctor.Update(
            request.FirstName,
            request.LastName,
            request.Email,
            request.PhoneNumber,
            request.Specialty);

        await _repository.UpdateAsync(doctor);

        return true;
    }
}