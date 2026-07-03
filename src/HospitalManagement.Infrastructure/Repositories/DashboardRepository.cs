using HospitalManagement.Application.DTOs.Dashboard;
using HospitalManagement.Application.Interfaces.Repositories;
using HospitalManagement.Infrastructure.Data; 
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Infrastructure.Repositories;

public class DashboardRepository : IDashboardRepository
{
    private readonly ApplicationDbContext _context;

    public DashboardRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DashboardStatisticsDto> GetStatisticsAsync(CancellationToken cancellationToken)
    {
        var today = DateTime.UtcNow.Date;

        return new DashboardStatisticsDto
        {
            TotalPatients = await _context.Patients.CountAsync(cancellationToken),

            AdmittedPatients = await _context.Patients.CountAsync(x => x.IsAdmitted, cancellationToken),

            DischargedPatients = await _context.Patients.CountAsync(x => !x.IsAdmitted, cancellationToken),

            TotalDoctors = await _context.Doctors.CountAsync(cancellationToken),

            AppointmentsToday = await _context.Appointments.CountAsync(x => x.AppointmentDate.Date == today, cancellationToken),

            // FIXED: Using IsCompleted boolean checks instead of the missing Status enum
            CompletedAppointments = await _context.Appointments.CountAsync(x => x.IsCompleted, cancellationToken),

            PendingAppointments = await _context.Appointments.CountAsync(x => !x.IsCompleted, cancellationToken),

            PendingLabTests = await _context.LabTests.CountAsync(x => x.Status.ToString() == "Pending", cancellationToken),

            LowStockMedicines = await _context.Medicines.CountAsync(x => x.QuantityInStock < 10, cancellationToken),

            // FIXED: Using TotalAmount instead of Amount
            TotalRevenue = await _context.Bills.Where(x => x.IsPaid).SumAsync(x => (decimal?)x.TotalAmount, cancellationToken) ?? 0,

            OutstandingBills = await _context.Bills.Where(x => !x.IsPaid).SumAsync(x => (decimal?)x.TotalAmount, cancellationToken) ?? 0,

            TotalNotifications = await _context.Notifications.CountAsync(cancellationToken)
        };
    }
}