using MediatR;

namespace HospitalManagement.Application.Features.Bills.Commands.CreateBill;

public record CreateBillCommand(
    Guid PatientId,
    Guid AppointmentId,
    decimal ConsultationFee,
    decimal LabFee,
    decimal MedicationFee,
    decimal OtherCharges
) : IRequest<Guid>;