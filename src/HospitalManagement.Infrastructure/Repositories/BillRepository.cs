using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using HospitalManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Infrastructure.Repositories;

public class BillRepository : IBillRepository
{
    private readonly ApplicationDbContext _context;

    public BillRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddAsync(Bill bill)
    {
        await _context.Bills.AddAsync(bill);

        await _context.SaveChangesAsync();

        return bill.Id;
    }

    public async Task<Bill?> GetByIdAsync(Guid id)
    {
        return await _context.Bills
            .Include(x => x.Patient)
            .Include(x => x.Appointment)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Bill>> GetAllAsync()
    {
        return await _context.Bills
            .Include(x => x.Patient)
            .Include(x => x.Appointment)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }

    public async Task UpdateAsync(Bill bill)
    {
        _context.Bills.Update(bill);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Bill bill)
    {
        _context.Bills.Remove(bill);

        await _context.SaveChangesAsync();
    }
}