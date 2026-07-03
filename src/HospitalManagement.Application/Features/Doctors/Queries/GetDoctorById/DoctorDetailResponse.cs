namespace HospitalManagement.Application.Features.Doctors.Queries.GetDoctorById;

public class DoctorDetailResponse
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public string Email { get; set; } = "";

    public string PhoneNumber { get; set; } = "";

    public string Specialty { get; set; } = "";
}