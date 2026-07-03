using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using HospitalManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Infrastructure.Repositories;

public class MedicineRepository : IMedicineRepository
{
    private readonly ApplicationDbContext _context;

    public MedicineRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Medicine medicine)
    {
        await _context.Medicines.AddAsync(medicine);
    }

    public async Task<Medicine?> GetByIdAsync(Guid id)
    {
        return await _context.Medicines
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Medicine>> GetAllAsync()
    {
        return await _context.Medicines
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task DeleteAsync(Medicine medicine)
    {
        _context.Medicines.Remove(medicine);

        await Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}