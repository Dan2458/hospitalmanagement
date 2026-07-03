using FluentValidation;

namespace HospitalManagement.Application.Features.MedicalRecords.Commands.CreateMedicalRecord;

public class CreateMedicalRecordValidator
    : AbstractValidator<CreateMedicalRecordCommand>
{
    public CreateMedicalRecordValidator()
    {
        RuleFor(x => x.AppointmentId)
            .NotEmpty();

        RuleFor(x => x.PatientId)
            .NotEmpty();

        RuleFor(x => x.DoctorId)
            .NotEmpty();

        RuleFor(x => x.Diagnosis)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.Symptoms)
            .MaximumLength(1000);

        RuleFor(x => x.Treatment)
            .MaximumLength(1000);

        RuleFor(x => x.Notes)
            .MaximumLength(2000);
    }
}