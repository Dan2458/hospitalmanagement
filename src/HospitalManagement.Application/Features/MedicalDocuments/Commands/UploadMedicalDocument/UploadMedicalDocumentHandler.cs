using FluentValidation;

namespace HospitalManagement.Application.Features.MedicalDocuments.Commands.UploadMedicalDocument;

public class UploadMedicalDocumentValidator
    : AbstractValidator<UploadMedicalDocumentCommand>
{
    public UploadMedicalDocumentValidator()
    {
        RuleFor(x => x.PatientId)
            .NotEmpty();

        RuleFor(x => x.FileName)
            .NotEmpty();

        RuleFor(x => x.ContentType)
            .NotEmpty();

        RuleFor(x => x.FileSize)
            .GreaterThan(0);
    }
}