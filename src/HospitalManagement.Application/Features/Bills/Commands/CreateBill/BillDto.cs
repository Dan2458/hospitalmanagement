namespace HospitalManagement.Application.Features.Bills.Commands.CreateBill;

public class BillDto
{
    public Guid Id { get; set; }

    public Guid PatientId { get; set; }

    public Guid AppointmentId { get; set; }

    public decimal ConsultationFee { get; set; }

    public decimal LabFee { get; set; }

    public decimal MedicationFee { get; set; }

    public decimal OtherCharges { get; set; }

    public decimal TotalAmount { get; set; }

    public bool IsPaid { get; set; }

    public DateTime CreatedAt { get; set; }
}