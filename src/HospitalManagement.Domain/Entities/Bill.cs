namespace HospitalManagement.Domain.Entities;

public class Bill
{
    public Guid Id { get; private set; }

    public Guid PatientId { get; private set; }

    public Guid AppointmentId { get; private set; }

    public decimal ConsultationFee { get; private set; }

    public decimal LabFee { get; private set; }

    public decimal MedicationFee { get; private set; }

    public decimal OtherCharges { get; private set; }

    public decimal TotalAmount { get; private set; }

    public bool IsPaid { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public Patient Patient { get; private set; } = default!;

    public Appointment Appointment { get; private set; } = default!;

    private Bill()
    {
    }

    public Bill(
        Guid patientId,
        Guid appointmentId,
        decimal consultationFee,
        decimal labFee,
        decimal medicationFee,
        decimal otherCharges)
    {
        Id = Guid.NewGuid();

        PatientId = patientId;

        AppointmentId = appointmentId;

        ConsultationFee = consultationFee;

        LabFee = labFee;

        MedicationFee = medicationFee;

        OtherCharges = otherCharges;

        TotalAmount =
            consultationFee +
            labFee +
            medicationFee +
            otherCharges;

        IsPaid = false;

        CreatedAt = DateTime.UtcNow;
    }

    public void MarkAsPaid()
    {
        IsPaid = true;
    }

    public void UpdateFees(
        decimal consultationFee,
        decimal labFee,
        decimal medicationFee,
        decimal otherCharges)
    {
        ConsultationFee = consultationFee;

        LabFee = labFee;

        MedicationFee = medicationFee;

        OtherCharges = otherCharges;

        TotalAmount =
            consultationFee +
            labFee +
            medicationFee +
            otherCharges;
    }
}