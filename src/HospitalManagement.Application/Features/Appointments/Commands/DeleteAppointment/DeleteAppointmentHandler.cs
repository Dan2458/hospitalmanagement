using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Appointments.Commands.DeleteAppointment;

public class DeleteAppointmentHandler
    : IRequestHandler<DeleteAppointmentCommand, bool>
{
    private readonly IAppointmentRepository _repository;

    public DeleteAppointmentHandler(IAppointmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteAppointmentCommand request,
        CancellationToken cancellationToken)
    {
        var appointment = await _repository.GetByIdAsync(request.Id);

        if (appointment is null)
            return false;

        await _repository.DeleteAsync(request.Id);

        return true;
    }
}