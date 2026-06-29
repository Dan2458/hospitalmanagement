using MediatR;

namespace HospitalManagement.Application.Features.Patients.Commands.AddBill;

public record AddBillCommand(
    Guid Id,
    decimal Amount
) : IRequest<bool>;