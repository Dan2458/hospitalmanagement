using MediatR;

namespace HospitalManagement.Application.Features.Bills.Queries.GetBillById;

public record GetBillByIdQuery(Guid Id)
    : IRequest<BillDetailsResponse?>;