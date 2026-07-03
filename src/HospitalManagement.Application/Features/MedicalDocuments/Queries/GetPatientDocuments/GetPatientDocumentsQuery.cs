using MediatR;

namespace HospitalManagement.Application.Features.MedicalDocuments.Queries.GetPatientDocuments;

public record GetPatientDocumentsQuery(Guid PatientId)
    : IRequest<List<MedicalDocumentDto>>;