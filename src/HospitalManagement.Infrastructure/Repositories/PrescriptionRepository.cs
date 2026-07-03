using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using HospitalManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Infrastructure.Repositories;

public class PrescriptionRepository : IPrescriptionRepository
{
    private readonly ApplicationDbContext _context;

    public PrescriptionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Prescription>> GetAllAsync()
    {
        return await _context.Prescriptions
            .Include(x => x.Patient)
            .Include(x => x.Doctor)
            .Include(x => x.Appointment)
            .ToListAsync();
    }

    public async Task<Prescription?> GetByIdAsync(Guid id)
    {
        return await _context.Prescriptions
            .Include(x => x.Patient)
            .Include(x => x.Doctor)
            .Include(x => x.Appointment)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Prescription>> GetByPatientIdAsync(Guid patientId)
    {
        return await _context.Prescriptions
            .Where(x => x.PatientId == patientId)
            .Include(x => x.Doctor)
            .Include(x => x.Appointment)
            .ToListAsync();
    }

    public async Task AddAsync(Prescription prescription)
    {
        await _context.Prescriptions.AddAsync(prescription);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Prescription prescription)
    {
        _context.Prescriptions.Update(prescription);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var prescription = await _context.Prescriptions.FindAsync(id);

        if (prescription is null)
            return;

        _context.Prescriptions.Remove(prescription);
        await _context.SaveChangesAsync();
    }
}