namespace HospitalManagement.Application.Features.Dashboard.Queries.GetDashboard;

public class DashboardDto
{
    public int TotalPatients { get; set; }

    public int TotalDoctors { get; set; }

    public int TotalAppointments { get; set; }

    public int CompletedAppointments { get; set; }

    public int TotalMedicalRecords { get; set; }
}