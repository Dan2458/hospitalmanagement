using MediatR;

namespace HospitalManagement.Application.Features.Bills.Queries.GetAllBills;

public record GetAllBillsQuery()
    : IRequest<List<BillResponse>>;