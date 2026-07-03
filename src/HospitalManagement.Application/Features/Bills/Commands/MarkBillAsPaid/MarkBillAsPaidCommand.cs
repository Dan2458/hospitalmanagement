using MediatR;

namespace HospitalManagement.Application.Features.Bills.Commands.MarkBillAsPaid;

public record MarkBillAsPaidCommand(Guid Id)
    : IRequest<bool>;