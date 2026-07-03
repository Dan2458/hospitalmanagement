using FluentValidation;

namespace HospitalManagement.Application.Features.Medicines.Commands.CreateMedicine;

public class CreateMedicineValidator
    : AbstractValidator<CreateMedicineCommand>
{
    public CreateMedicineValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.GenericName)
            .NotEmpty();

        RuleFor(x => x.Manufacturer)
            .NotEmpty();

        RuleFor(x => x.Category)
            .NotEmpty();

        RuleFor(x => x.Barcode)
            .NotEmpty();

        RuleFor(x => x.UnitPrice)
            .GreaterThan(0);

        RuleFor(x => x.QuantityInStock)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.ReorderLevel)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.ExpiryDate)
            .GreaterThan(DateTime.Today);
    }
}