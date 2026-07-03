namespace HospitalManagement.Application.Interfaces.Identity;

public interface IIdentityService
{
    Task<(bool Succeeded, IEnumerable<string> Errors)> RegisterAsync(
        string firstName,
        string lastName,
        string email,
        string password,
        string role);

    Task<string?> LoginAsync(
        string email,
        string password);
}