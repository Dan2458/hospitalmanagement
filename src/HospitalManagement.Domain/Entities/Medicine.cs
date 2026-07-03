namespace HospitalManagement.Domain.Entities;

public class Medicine
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string GenericName { get; private set; } = string.Empty;

    public string Manufacturer { get; private set; } = string.Empty;

    public string Category { get; private set; } = string.Empty;

    public string Barcode { get; private set; } = string.Empty;

    public decimal UnitPrice { get; private set; }

    public int QuantityInStock { get; private set; }

    public int ReorderLevel { get; private set; }

    public DateTime ExpiryDate { get; private set; }

    public bool IsActive { get; private set; }

    private Medicine()
    {
    }

    public Medicine(
        string name,
        string genericName,
        string manufacturer,
        string category,
        string barcode,
        decimal unitPrice,
        int quantityInStock,
        int reorderLevel,
        DateTime expiryDate)
    {
        Id = Guid.NewGuid();
        Name = name;
        GenericName = genericName;
        Manufacturer = manufacturer;
        Category = category;
        Barcode = barcode;
        UnitPrice = unitPrice;
        QuantityInStock = quantityInStock;
        ReorderLevel = reorderLevel;
        ExpiryDate = expiryDate;
        IsActive = true;
    }

    public void ReduceStock(int quantity)
    {
        if (quantity > QuantityInStock)
            throw new InvalidOperationException("Insufficient stock.");

        QuantityInStock -= quantity;
    }

    public void IncreaseStock(int quantity)
    {
        QuantityInStock += quantity;
    }

    public void UpdatePrice(decimal price)
    {
        UnitPrice = price;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}