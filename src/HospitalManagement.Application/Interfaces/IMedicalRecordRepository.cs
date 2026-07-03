using HospitalManagement.Domain.Entities;

namespace HospitalManagement.Application.Interfaces;

public interface IMedicalRecordRepository
{
    Task<List<MedicalRecord>> GetAllAsync();

    Task<MedicalRecord?> GetByIdAsync(Guid id);

    Task AddAsync(MedicalRecord record);

    Task UpdateAsync(MedicalRecord record);

    Task DeleteAsync(Guid id);

    Task<List<MedicalRecord>> GetPatientHistoryAsync(Guid patientId);
    Task<int> CountAsync();
}