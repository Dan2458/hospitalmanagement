using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Bills.Queries.GetAllBills;

public class GetAllBillsQueryHandler
    : IRequestHandler<GetAllBillsQuery, List<BillResponse>>
{
    private readonly IBillRepository _repository;

    public GetAllBillsQueryHandler(
        IBillRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<BillResponse>> Handle(
        GetAllBillsQuery request,
        CancellationToken cancellationToken)
    {
        var bills = await _repository.GetAllAsync();

        return bills.Select(x => new BillResponse
        {
            Id = x.Id,

            PatientId = x.PatientId,

            AppointmentId = x.AppointmentId,

            PatientName = $"{x.Patient.FirstName} {x.Patient.LastName}",

            ConsultationFee = x.ConsultationFee,

            LabFee = x.LabFee,

            MedicationFee = x.MedicationFee,

            OtherCharges = x.OtherCharges,

            TotalAmount = x.TotalAmount,

            IsPaid = x.IsPaid,

            CreatedAt = x.CreatedAt
        }).ToList();
    }
}