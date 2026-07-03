using HospitalManagement.Domain.Common;

namespace HospitalManagement.Domain.Entities;

public class Appointment : BaseEntity
{
    public Guid PatientId { get; private set; }

    public Guid DoctorId { get; private set; }

    public DateTime AppointmentDate { get; private set; }

    public string Reason { get; private set; }

    public bool IsCompleted { get; private set; }

    public Patient Patient { get; private set; } = null!;

    public Doctor Doctor { get; private set; } = null!;

    private Appointment()
    {
    }

    public Appointment(
        Guid patientId,
        Guid doctorId,
        DateTime appointmentDate,
        string reason)
    {
        PatientId = patientId;
        DoctorId = doctorId;
        AppointmentDate = appointmentDate;
        Reason = reason;
    }

    public void Complete()
    {
        IsCompleted = true;
        MarkAsUpdated();
    }
}