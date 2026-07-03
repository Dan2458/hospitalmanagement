using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Bills.Queries.GetBillById;

public class GetBillByIdQueryHandler
    : IRequestHandler<GetBillByIdQuery, BillDetailsResponse?>
{
    private readonly IBillRepository _repository;

    public GetBillByIdQueryHandler(
        IBillRepository repository)
    {
        _repository = repository;
    }

    public async Task<BillDetailsResponse?> Handle(
        GetBillByIdQuery request,
        CancellationToken cancellationToken)
    {
        var bill = await _repository.GetByIdAsync(request.Id);

        if (bill is null)
            return null;

        return new BillDetailsResponse
        {
            Id = bill.Id,

            PatientId = bill.PatientId,

            AppointmentId = bill.AppointmentId,

            PatientName = $"{bill.Patient.FirstName} {bill.Patient.LastName}",

            ConsultationFee = bill.ConsultationFee,

            LabFee = bill.LabFee,

            MedicationFee = bill.MedicationFee,

            OtherCharges = bill.OtherCharges,

            TotalAmount = bill.TotalAmount,

            IsPaid = bill.IsPaid,

            CreatedAt = bill.CreatedAt
        };
    }
}