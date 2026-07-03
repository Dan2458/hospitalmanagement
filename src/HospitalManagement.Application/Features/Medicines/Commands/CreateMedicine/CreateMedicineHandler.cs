using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.Medicines.Commands.CreateMedicine;

public class CreateMedicineHandler
    : IRequestHandler<CreateMedicineCommand, Guid>
{
    private readonly IMedicineRepository _repository;

    public CreateMedicineHandler(IMedicineRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(
        CreateMedicineCommand request,
        CancellationToken cancellationToken)
    {
        var medicine = new Medicine(
            request.Name,
            request.GenericName,
            request.Manufacturer,
            request.Category,
            request.Barcode,
            request.UnitPrice,
            request.QuantityInStock,
            request.ReorderLevel,
            request.ExpiryDate);

        await _repository.AddAsync(medicine);

        await _repository.SaveChangesAsync();

        return medicine.Id;
    }
}