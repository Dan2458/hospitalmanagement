using HospitalManagement.Domain.Entities;

namespace HospitalManagement.Application.Interfaces;

public interface IBillRepository
{
    Task<Guid> AddAsync(Bill bill);

    Task<Bill?> GetByIdAsync(Guid id);

    Task<List<Bill>> GetAllAsync();

    Task UpdateAsync(Bill bill);

    Task DeleteAsync(Bill bill);
}