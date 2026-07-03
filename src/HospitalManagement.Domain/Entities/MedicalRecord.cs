using HospitalManagement.Domain.Common;

namespace HospitalManagement.Domain.Entities;

public class MedicalRecord : BaseEntity
{
    public Guid AppointmentId { get; private set; }

    public Guid PatientId { get; private set; }

    public Guid DoctorId { get; private set; }

    public string Diagnosis { get; private set; }

    public string Symptoms { get; private set; }

    public string Treatment { get; private set; }

    public string Notes { get; private set; }

    public Appointment Appointment { get; private set; } = null!;

    public Patient Patient { get; private set; } = null!;

    public Doctor Doctor { get; private set; } = null!;

    private MedicalRecord()
    {
    }

    public MedicalRecord(
        Guid appointmentId,
        Guid patientId,
        Guid doctorId,
        string diagnosis,
        string symptoms,
        string treatment,
        string notes)
    {
        AppointmentId = appointmentId;
        PatientId = patientId;
        DoctorId = doctorId;
        Diagnosis = diagnosis;
        Symptoms = symptoms;
        Treatment = treatment;
        Notes = notes;
    }

    public void Update(
        string diagnosis,
        string symptoms,
        string treatment,
        string notes)
    {
        Diagnosis = diagnosis;
        Symptoms = symptoms;
        Treatment = treatment;
        Notes = notes;

        MarkAsUpdated();
        
    }

}

    
