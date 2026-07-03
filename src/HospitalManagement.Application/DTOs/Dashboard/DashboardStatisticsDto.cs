namespace HospitalManagement.Application.DTOs.Dashboard;

public class DashboardStatisticsDto
{
    public int TotalPatients { get; set; }

    public int AdmittedPatients { get; set; }

    public int DischargedPatients { get; set; }

    public int TotalDoctors { get; set; }

    public int AppointmentsToday { get; set; }

    public int CompletedAppointments { get; set; }

    public int PendingAppointments { get; set; }

    public int PendingLabTests { get; set; }

    public int LowStockMedicines { get; set; }

    public decimal TotalRevenue { get; set; }

    public decimal OutstandingBills { get; set; }

    public int TotalNotifications { get; set; }
}