namespace HospitalManagement.Application.Features.Bills.Queries.GetAllBills;

public class BillResponse
{
    public Guid Id { get; set; }

    public Guid PatientId { get; set; }

    public Guid AppointmentId { get; set; }

    public string PatientName { get; set; } = string.Empty;

    public decimal ConsultationFee { get; set; }

    public decimal LabFee { get; set; }

    public decimal MedicationFee { get; set; }

    public decimal OtherCharges { get; set; }

    public decimal TotalAmount { get; set; }

    public bool IsPaid { get; set; }

    public DateTime CreatedAt { get; set; }
}