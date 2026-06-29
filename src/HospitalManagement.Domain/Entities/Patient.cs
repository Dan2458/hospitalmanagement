using HospitalManagement.Domain.Common;

namespace HospitalManagement.Domain.Entities;

public class Patient : BaseEntity
{
    // Required by EF Core
    private Patient()
    {
    }

    public Patient(
        string firstName,
        string lastName,
        DateTime dateOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
    }

    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public DateTime DateOfBirth { get; private set; }

    public bool IsAdmitted { get; private set; }

    public decimal OutstandingBalance { get; private set; }

    public string FullName => $"{FirstName} {LastName}";

    public void Admit()
    {
        IsAdmitted = true;
        MarkAsUpdated();
    }

    public void Discharge()
    {
        IsAdmitted = false;
        MarkAsUpdated();
    }

    public void AddBill(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        OutstandingBalance += amount;

        MarkAsUpdated();
    }

    public void PayBill(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        if (amount > OutstandingBalance)
            throw new InvalidOperationException("Payment exceeds outstanding balance.");

        OutstandingBalance -= amount;

        MarkAsUpdated();
    }

public void UpdateInformation(
    string firstName,
    string lastName,
    DateTime dateOfBirth)
{
    if (string.IsNullOrWhiteSpace(firstName))
        throw new ArgumentException("First name is required.");

    if (string.IsNullOrWhiteSpace(lastName))
        throw new ArgumentException("Last name is required.");

    if (dateOfBirth > DateTime.Today)
        throw new ArgumentException("Invalid date of birth.");

    FirstName = firstName;
    LastName = lastName;
    DateOfBirth = dateOfBirth;

    MarkAsUpdated();
}


    public int GetAge()
    {
        var age = DateTime.Today.Year - DateOfBirth.Year;

        if (DateOfBirth.Date > DateTime.Today.AddYears(-age))
            age--;

        return age;
    }
}