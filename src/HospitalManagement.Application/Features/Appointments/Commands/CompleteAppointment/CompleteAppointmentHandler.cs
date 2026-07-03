using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Appointments.Commands.CompleteAppointment;

public class CompleteAppointmentHandler
    : IRequestHandler<CompleteAppointmentCommand, bool>
{
    private readonly IAppointmentRepository _repository;

    public CompleteAppointmentHandler(IAppointmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        CompleteAppointmentCommand request,
        CancellationToken cancellationToken)
    {
        var appointment = await _repository.GetByIdAsync(request.Id);

        if (appointment is null)
            return false;

        // ✅ Use the domain method instead of assigning the property
        appointment.Complete();

        await _repository.UpdateAsync(appointment);

        return true;
    }
}