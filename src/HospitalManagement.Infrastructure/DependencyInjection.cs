using HospitalManagement.Application.Interfaces;
using HospitalManagement.Application.Interfaces.Identity;
using HospitalManagement.Infrastructure.Data;
using HospitalManagement.Infrastructure.Identity;
using HospitalManagement.Infrastructure.Repositories;
using HospitalManagement.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HospitalManagement.Application.Common.JWT;
using HospitalManagement.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HospitalManagement.Application.Interfaces;
using HospitalManagement.Application.Interfaces.FileStorage;
using HospitalManagement.Infrastructure.Repositories;
using HospitalManagement.Infrastructure.FileStorage;
namespace HospitalManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
            services.AddScoped<IMedicalDocumentRepository, MedicalDocumentRepository>();

            services.AddScoped<IFileStorageService, LocalFileStorageService>();
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<ILabTestRepository, LabTestRepository>();
            services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
            services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
         services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IIdentityService, IdentityService>();
// JWT Settings
services.Configure<JwtSettings>(
    configuration.GetSection("Jwt"));

// JWT Generator
services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

// JWT Authentication
services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;

    options.DefaultChallengeScheme =
        JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters =
        new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],

            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        configuration["Jwt:Key"]!))
        };
});

        return services;

        
    }
    
    
}