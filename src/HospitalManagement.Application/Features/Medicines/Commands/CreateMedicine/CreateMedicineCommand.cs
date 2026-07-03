using MediatR;

namespace HospitalManagement.Application.Features.Medicines.Commands.CreateMedicine;

public record CreateMedicineCommand(
    string Name,
    string GenericName,
    string Manufacturer,
    string Category,
    string Barcode,
    decimal UnitPrice,
    int QuantityInStock,
    int ReorderLevel,
    DateTime ExpiryDate
) : IRequest<Guid>;