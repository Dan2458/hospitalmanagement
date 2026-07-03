using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using HospitalManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Infrastructure.Repositories;

public class MedicalDocumentRepository : IMedicalDocumentRepository
{
    private readonly ApplicationDbContext _context;

    public MedicalDocumentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(MedicalDocument document)
    {
        await _context.MedicalDocuments.AddAsync(document);
    }

    public async Task<MedicalDocument?> GetByIdAsync(Guid id)
    {
        return await _context.MedicalDocuments
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<MedicalDocument>> GetPatientDocumentsAsync(Guid patientId)
    {
        return await _context.MedicalDocuments
            .Where(x => x.PatientId == patientId)
            .OrderByDescending(x => x.UploadedAt)
            .ToListAsync();
    }

    public async Task DeleteAsync(MedicalDocument document)
    {
        _context.MedicalDocuments.Remove(document);

        await Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}