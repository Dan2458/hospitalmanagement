using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using HospitalManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Infrastructure.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly ApplicationDbContext _context;

    public DoctorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Doctor>> GetAllAsync()
    {
        return await _context.Doctors.ToListAsync();
    }

    public async Task<Doctor?> GetByIdAsync(Guid id)
    {
        return await _context.Doctors.FindAsync(id);
    }

    public async Task AddAsync(Doctor doctor)
    {
        await _context.Doctors.AddAsync(doctor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Doctor doctor)
    {
        _context.Doctors.Update(doctor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var doctor = await _context.Doctors.FindAsync(id);

        if (doctor is null)
            return;

        _context.Doctors.Remove(doctor);
        await _context.SaveChangesAsync();
    }
    public async Task<int> CountAsync()
{
    return await _context.Doctors.CountAsync();
}
}