using FluentValidation;

namespace HospitalManagement.Application.Features.Appointments.Commands.CreateAppointment;

public class CreateAppointmentValidator
    : AbstractValidator<CreateAppointmentCommand>
{
    public CreateAppointmentValidator()
    {
        RuleFor(x => x.PatientId)
            .NotEmpty();

        RuleFor(x => x.DoctorId)
            .NotEmpty();

        RuleFor(x => x.Reason)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.AppointmentDate)
            .GreaterThan(DateTime.Now);
    }
}