using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Bills.Commands.MarkBillAsPaid;

public class MarkBillAsPaidCommandHandler
    : IRequestHandler<MarkBillAsPaidCommand, bool>
{
    private readonly IBillRepository _repository;

    public MarkBillAsPaidCommandHandler(
        IBillRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        MarkBillAsPaidCommand request,
        CancellationToken cancellationToken)
    {
        var bill = await _repository.GetByIdAsync(request.Id);

        if (bill is null)
            return false;

        bill.MarkAsPaid();

        await _repository.UpdateAsync(bill);

        return true;
    }
}