using HospitalManagement.Domain.Common;

namespace HospitalManagement.Domain.Entities;

public class Prescription : BaseEntity
{
    public Guid PatientId { get; private set; }

    public Guid DoctorId { get; private set; }

    public Guid AppointmentId { get; private set; }

    public string Medication { get; private set; }

    public string Dosage { get; private set; }

    public string Frequency { get; private set; }

    public string Duration { get; private set; }

    public string Instructions { get; private set; }

    public Patient Patient { get; private set; } = null!;

    public Doctor Doctor { get; private set; } = null!;

    public Appointment Appointment { get; private set; } = null!;

    private Prescription()
    {
    }

    public Prescription(
        Guid patientId,
        Guid doctorId,
        Guid appointmentId,
        string medication,
        string dosage,
        string frequency,
        string duration,
        string instructions)
    {
        PatientId = patientId;
        DoctorId = doctorId;
        AppointmentId = appointmentId;
        Medication = medication;
        Dosage = dosage;
        Frequency = frequency;
        Duration = duration;
        Instructions = instructions;
    }

    public void Update(
        string medication,
        string dosage,
        string frequency,
        string duration,
        string instructions)
    {
        Medication = medication;
        Dosage = dosage;
        Frequency = frequency;
        Duration = duration;
        Instructions = instructions;

        MarkAsUpdated();
    }
}