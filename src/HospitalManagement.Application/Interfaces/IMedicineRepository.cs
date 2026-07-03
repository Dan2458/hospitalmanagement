using HospitalManagement.Domain.Entities;

namespace HospitalManagement.Application.Interfaces;

public interface IMedicineRepository
{
    Task AddAsync(Medicine medicine);

    Task<Medicine?> GetByIdAsync(Guid id);

    Task<List<Medicine>> GetAllAsync();

    Task DeleteAsync(Medicine medicine);

    Task SaveChangesAsync();
}