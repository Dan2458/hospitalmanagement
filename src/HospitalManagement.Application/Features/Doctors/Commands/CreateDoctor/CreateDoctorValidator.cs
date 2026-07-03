using FluentValidation;

namespace HospitalManagement.Application.Features.Doctors.Commands.CreateDoctor;

public class CreateDoctorValidator
    : AbstractValidator<CreateDoctorCommand>
{
    public CreateDoctorValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.PhoneNumber)
            .NotEmpty();

        RuleFor(x => x.Specialty)
            .NotEmpty();
    }
}