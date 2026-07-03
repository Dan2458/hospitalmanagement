using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Doctors.Commands.DeleteDoctor;

public class DeleteDoctorHandler
    : IRequestHandler<DeleteDoctorCommand, bool>
{
    private readonly IDoctorRepository _repository;

    public DeleteDoctorHandler(IDoctorRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteDoctorCommand request,
        CancellationToken cancellationToken)
    {
        var doctor = await _repository.GetByIdAsync(request.Id);

        if (doctor is null)
            return false;

        await _repository.DeleteAsync(request.Id);

        return true;
    }
}