using FluentValidation;

namespace HospitalManagement.Application.Features.Bills.Commands.CreateBill;

public class CreateBillValidator : AbstractValidator<CreateBillCommand>
{
    public CreateBillValidator()
    {
        RuleFor(x => x.PatientId).NotEmpty();

        RuleFor(x => x.AppointmentId).NotEmpty();

        RuleFor(x => x.ConsultationFee)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.LabFee)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.MedicationFee)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.OtherCharges)
            .GreaterThanOrEqualTo(0);
    }
}