using HospitalManagement.Domain.Entities;

namespace HospitalManagement.Application.Interfaces;

public interface ILabTestRepository
{
    Task<List<LabTest>> GetAllAsync();

    Task<LabTest?> GetByIdAsync(Guid id);

    Task AddAsync(LabTest labTest);

    Task UpdateAsync(LabTest labTest);

    Task DeleteAsync(Guid id);
}