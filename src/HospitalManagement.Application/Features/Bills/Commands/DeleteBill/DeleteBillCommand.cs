using MediatR;

namespace HospitalManagement.Application.Features.Bills.Commands.DeleteBill;

public record DeleteBillCommand(Guid Id)
    : IRequest<bool>;