using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using HospitalManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Infrastructure.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly ApplicationDbContext _context;

    public AppointmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Appointment>> GetAllAsync()
    {
        return await _context.Appointments
            .Include(x => x.Patient)
            .Include(x => x.Doctor)
            .ToListAsync();
    }

    public async Task<Appointment?> GetByIdAsync(Guid id)
    {
        return await _context.Appointments
            .Include(x => x.Patient)
            .Include(x => x.Doctor)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Appointment appointment)
    {
        await _context.Appointments.AddAsync(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Appointment appointment)
    {
        _context.Appointments.Update(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var appointment = await _context.Appointments.FindAsync(id);

        if (appointment is null)
            return;

        _context.Appointments.Remove(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(
        Guid doctorId,
        DateTime appointmentDate)
    {
        return await _context.Appointments.AnyAsync(x =>
            x.DoctorId == doctorId &&
            x.AppointmentDate == appointmentDate &&
            !x.IsCompleted);
    }
    public async Task<int> CountAsync()
{
    return await _context.Appointments.CountAsync();
}

public async Task<int> CountCompletedAsync()
{
    return await _context.Appointments
        .CountAsync(x => x.IsCompleted);
}
}