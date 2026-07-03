using HospitalManagement.Application.Interfaces;
using MediatR;

namespace HospitalManagement.Application.Features.Bills.Commands.DeleteBill;

public class DeleteBillCommandHandler
    : IRequestHandler<DeleteBillCommand, bool>
{
    private readonly IBillRepository _repository;

    public DeleteBillCommandHandler(
        IBillRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteBillCommand request,
        CancellationToken cancellationToken)
    {
        var bill = await _repository.GetByIdAsync(request.Id);

        if (bill is null)
            return false;

        await _repository.DeleteAsync(bill);

        return true;
    }
}