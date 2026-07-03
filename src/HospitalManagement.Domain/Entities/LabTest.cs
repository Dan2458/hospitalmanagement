using HospitalManagement.Domain.Common;

namespace HospitalManagement.Domain.Entities;

public class LabTest : BaseEntity
{
    public Guid PatientId { get; private set; }

    public Guid DoctorId { get; private set; }

    public Guid AppointmentId { get; private set; }

    public string TestName { get; private set; }

    public string Result { get; private set; }

    public string Status { get; private set; }

    public DateTime RequestedDate { get; private set; }

    public DateTime? CompletedDate { get; private set; }

    public Patient Patient { get; private set; } = null!;

    public Doctor Doctor { get; private set; } = null!;

    public Appointment Appointment { get; private set; } = null!;

    private LabTest()
    {
    }

    public LabTest(
        Guid patientId,
        Guid doctorId,
        Guid appointmentId,
        string testName)
    {
        PatientId = patientId;
        DoctorId = doctorId;
        AppointmentId = appointmentId;
        TestName = testName;

        Status = "Pending";
        RequestedDate = DateTime.UtcNow;
        Result = "";
    }

    public void Complete(string result)
    {
        Result = result;
        Status = "Completed";
        CompletedDate = DateTime.UtcNow;

        MarkAsUpdated();
    }
}

