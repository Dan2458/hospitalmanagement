using HospitalManagement.Domain.Entities;

namespace HospitalManagement.Application.Interfaces;

public interface IMedicalDocumentRepository
{
    Task AddAsync(MedicalDocument document);

    Task<MedicalDocument?> GetByIdAsync(Guid id);

    Task<List<MedicalDocument>> GetPatientDocumentsAsync(Guid patientId);

    Task DeleteAsync(MedicalDocument document);

    Task SaveChangesAsync();
}