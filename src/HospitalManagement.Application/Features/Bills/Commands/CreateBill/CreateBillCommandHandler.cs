using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.Bills.Commands.CreateBill;

public class CreateBillCommandHandler
    : IRequestHandler<CreateBillCommand, Guid>
{
    private readonly IBillRepository _repository;

    public CreateBillCommandHandler(
        IBillRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(
        CreateBillCommand request,
        CancellationToken cancellationToken)
    {
        var bill = new Bill(
            request.PatientId,
            request.AppointmentId,
            request.ConsultationFee,
            request.LabFee,
            request.MedicationFee,
            request.OtherCharges);

        return await _repository.AddAsync(bill);
    }
}