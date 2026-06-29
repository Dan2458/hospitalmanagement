namespace HospitalManagement.Application.Features.Patients.Queries.GetPatientById;

public class PatientDetailResponse
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    public bool IsAdmitted { get; set; }

    public decimal OutstandingBalance { get; set; }

    public int Age { get; set; }
}