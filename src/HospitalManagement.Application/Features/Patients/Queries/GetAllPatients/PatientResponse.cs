namespace HospitalManagement.Application.Features.Patients.Queries.GetAllPatients;

public class PatientResponse
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public bool IsAdmitted { get; set; }

    public decimal OutstandingBalance { get; set; }

    public int Age { get; set; }
}