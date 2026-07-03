using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using HospitalManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Infrastructure.Repositories;

public class MedicalRecordRepository : IMedicalRecordRepository
{
    private readonly ApplicationDbContext _context;

    public MedicalRecordRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<MedicalRecord>> GetAllAsync()
    {
        return await _context.MedicalRecords
            .Include(x => x.Patient)
            .Include(x => x.Doctor)
            .Include(x => x.Appointment)
            .ToListAsync();
    }

    public async Task<MedicalRecord?> GetByIdAsync(Guid id)
    {
        return await _context.MedicalRecords
            .Include(x => x.Patient)
            .Include(x => x.Doctor)
            .Include(x => x.Appointment)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(MedicalRecord record)
    {
        await _context.MedicalRecords.AddAsync(record);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(MedicalRecord record)
    {
        _context.MedicalRecords.Update(record);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var record = await _context.MedicalRecords.FindAsync(id);

        if (record == null)
            return;

        _context.MedicalRecords.Remove(record);
        await _context.SaveChangesAsync();
    }

    public async Task<List<MedicalRecord>> GetPatientHistoryAsync(Guid patientId)
    {
        return await _context.MedicalRecords
            .Where(x => x.PatientId == patientId)
            .Include(x => x.Doctor)
            .Include(x => x.Appointment)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }
    public async Task<int> CountAsync()
{
    return await _context.MedicalRecords.CountAsync();
}
}