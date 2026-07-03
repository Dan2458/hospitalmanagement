using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using HospitalManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Infrastructure.Repositories;

public class LabTestRepository : ILabTestRepository
{
    private readonly ApplicationDbContext _context;

    public LabTestRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<LabTest>> GetAllAsync()
    {
        return await _context.LabTests
            .Include(x => x.Patient)
            .Include(x => x.Doctor)
            .Include(x => x.Appointment)
            .ToListAsync();
    }

    public async Task<LabTest?> GetByIdAsync(Guid id)
    {
        return await _context.LabTests
            .Include(x => x.Patient)
            .Include(x => x.Doctor)
            .Include(x => x.Appointment)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(LabTest labTest)
    {
        await _context.LabTests.AddAsync(labTest);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(LabTest labTest)
    {
        _context.LabTests.Update(labTest);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var labTest = await _context.LabTests.FindAsync(id);

        if (labTest == null)
            return;

        _context.LabTests.Remove(labTest);
        await _context.SaveChangesAsync();
    }
}