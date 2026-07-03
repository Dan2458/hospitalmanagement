// using HospitalManagement.Application.Interfaces.Identity;
// using HospitalManagement.Infrastructure.Identity;
// using Microsoft.AspNetCore.Identity;

// namespace HospitalManagement.Infrastructure.Services;

// public class IdentityService : IIdentityService
// {
//     private readonly UserManager<ApplicationUser> _userManager;

//     public IdentityService(UserManager<ApplicationUser> userManager)
//     {
//         _userManager = userManager;
//     }

//     public async Task<(bool Succeeded, IEnumerable<string> Errors)> RegisterAsync(
//         string firstName,
//         string lastName,
//         string email,
//         string password)
//     {
//         var user = new ApplicationUser
//         {
//             FirstName = firstName,
//             LastName = lastName,
//             UserName = email,
//             Email = email
//         };

//         var result = await _userManager.CreateAsync(user, password);

//         if (result.Succeeded)
//         {
//             return (true, Enumerable.Empty<string>());
//         }

//         return (
//             false,
//             result.Errors.Select(e => e.Description)
//         );
//     }

//     public async Task<string?> LoginAsync(
//         string email,
//         string password)
//     {
//         var user = await _userManager.FindByEmailAsync(email);

//         if (user is null)
//             return null;

//         var valid = await _userManager.CheckPasswordAsync(user, password);

//         if (!valid)
//             return null;

//         // JWT token will be implemented later
//         return "LOGIN_SUCCESS";
//     }
// }

using HospitalManagement.Application.Common.JWT;
using HospitalManagement.Application.Interfaces.Identity;
using HospitalManagement.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace HospitalManagement.Infrastructure.Services;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<(bool Succeeded, IEnumerable<string> Errors)> RegisterAsync(
        string firstName,
        string lastName,
        string email,
        string password,
        string role)
    {
        var user = new ApplicationUser
        {
            FirstName = firstName,
            LastName = lastName,
            UserName = email,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            return (
                false,
                result.Errors.Select(e => e.Description)
            );
        }

        if (!await _roleManager.RoleExistsAsync(role))
        {
            await _roleManager.CreateAsync(new IdentityRole(role));
        }

        await _userManager.AddToRoleAsync(user, role);

        return (true, Enumerable.Empty<string>());
    }

    public async Task<string?> LoginAsync(
        string email,
        string password)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
            return null;

        var valid = await _userManager.CheckPasswordAsync(user, password);

        if (!valid)
            return null;

        var roles = await _userManager.GetRolesAsync(user);

        return _jwtTokenGenerator.GenerateToken(
            user.Id,
            user.Email!,
            roles);
    }
}