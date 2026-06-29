using MediatR;

namespace HospitalManagement.Application.Features.Patients.Commands.PayBill;

public record PayBillCommand(
    Guid Id,
    decimal Amount
) : IRequest<bool>;