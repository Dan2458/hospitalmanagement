using HospitalManagement.Domain.Common;

namespace HospitalManagement.Domain.Entities;

public class Doctor : BaseEntity
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    public string PhoneNumber { get; private set; }

    public string Specialty { get; private set; }

    private Doctor()
    {
    }

    public Doctor(
        string firstName,
        string lastName,
        string email,
        string phoneNumber,
        string specialty)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Specialty = specialty;
    }

    public void Update(
        string firstName,
        string lastName,
        string email,
        string phoneNumber,
        string specialty)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Specialty = specialty;

        MarkAsUpdated();
    }
}