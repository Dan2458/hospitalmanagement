namespace HospitalManagement.Application.Features.Appointments.Queries.GetAllAppointments;

public class AppointmentResponse
{
    public Guid Id { get; set; }

    public string PatientName { get; set; } = string.Empty;

    public string DoctorName { get; set; } = string.Empty;

    public DateTime AppointmentDate { get; set; }

    public string Reason { get; set; } = string.Empty;

    public bool IsCompleted { get; set; }
}