using HospitalManagement.Domain.Entities;

namespace HospitalManagement.Application.Interfaces;

public interface IPrescriptionRepository
{
    Task<List<Prescription>> GetAllAsync();

    Task<Prescription?> GetByIdAsync(Guid id);

    Task<List<Prescription>> GetByPatientIdAsync(Guid patientId);

    Task AddAsync(Prescription prescription);

    Task UpdateAsync(Prescription prescription);

    Task DeleteAsync(Guid id);
}
