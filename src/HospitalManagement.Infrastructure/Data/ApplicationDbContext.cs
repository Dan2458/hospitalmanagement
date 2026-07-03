using HospitalManagement.Domain.Entities;
using HospitalManagement.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Doctor> Doctors => Set<Doctor>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<MedicalRecord> MedicalRecords => Set<MedicalRecord>();
    public DbSet<Prescription> Prescriptions => Set<Prescription>();
    public DbSet<LabTest> LabTests => Set<LabTest>();
    public DbSet<Bill> Bills => Set<Bill>();
    public DbSet<MedicalDocument> MedicalDocuments => Set<MedicalDocument>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // =========================
        // PATIENT
        // =========================
        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.LastName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.OutstandingBalance)
                .HasColumnType("decimal(18,2)");
        });

        // =========================
        // DOCTOR
        // =========================
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.LastName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.Email)
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(x => x.PhoneNumber)
                .HasMaxLength(20);

            entity.Property(x => x.Specialty)
                .HasMaxLength(100)
                .IsRequired();
        });

        // =========================
        // APPOINTMENT
        // =========================
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Reason)
                .HasMaxLength(500);

            entity.HasOne(x => x.Patient)
                .WithMany()
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.Doctor)
                .WithMany()
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // =========================
        // MEDICAL RECORD
        // =========================
        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Diagnosis)
                .HasMaxLength(500)
                .IsRequired();

            entity.Property(x => x.Symptoms)
                .HasMaxLength(1000);

            entity.Property(x => x.Treatment)
                .HasMaxLength(1000);

            entity.Property(x => x.Notes)
                .HasMaxLength(2000);

            entity.HasOne(x => x.Patient)
                .WithMany()
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.Doctor)
                .WithMany()
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.Appointment)
                .WithMany()
                .HasForeignKey(x => x.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // =========================
        // PRESCRIPTION
        // =========================
        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Medication)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(x => x.Dosage)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.Frequency)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.Duration)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.Instructions)
                .HasMaxLength(1000);

            entity.HasOne(x => x.Patient)
                .WithMany()
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(x => x.Doctor)
                .WithMany()
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(x => x.Appointment)
                .WithMany()
                .HasForeignKey(x => x.AppointmentId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        // =========================
        // LAB TEST
        // =========================
        modelBuilder.Entity<LabTest>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.TestName)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(x => x.Result)
                .HasMaxLength(5000);

            entity.Property(x => x.Status)
                .HasMaxLength(50);

            entity.HasOne(x => x.Patient)
                .WithMany()
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(x => x.Doctor)
                .WithMany()
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(x => x.Appointment)
                .WithMany()
                .HasForeignKey(x => x.AppointmentId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Bill>(entity =>
{
    entity.HasKey(x => x.Id);

    entity.Property(x => x.ConsultationFee)
        .HasColumnType("decimal(18,2)");

    entity.Property(x => x.LabFee)
        .HasColumnType("decimal(18,2)");

    entity.Property(x => x.MedicationFee)
        .HasColumnType("decimal(18,2)");

    entity.Property(x => x.OtherCharges)
        .HasColumnType("decimal(18,2)");

    entity.Property(x => x.TotalAmount)
        .HasColumnType("decimal(18,2)");

    entity.Property(x => x.IsPaid)
        .IsRequired();

    entity.Property(x => x.CreatedAt)
        .IsRequired();

    entity.HasOne(x => x.Patient)
        .WithMany()
        .HasForeignKey(x => x.PatientId)
        .OnDelete(DeleteBehavior.NoAction);

    entity.HasOne(x => x.Appointment)
        .WithMany()
        .HasForeignKey(x => x.AppointmentId)
        .OnDelete(DeleteBehavior.NoAction);
});


modelBuilder.Entity<MedicalDocument>(entity =>
{
    entity.HasKey(x => x.Id);

    entity.Property(x => x.FileName)
        .HasMaxLength(300)
        .IsRequired();

    entity.Property(x => x.OriginalFileName)
        .HasMaxLength(300)
        .IsRequired();

    entity.Property(x => x.ContentType)
        .HasMaxLength(100)
        .IsRequired();

    entity.Property(x => x.FilePath)
        .HasMaxLength(500)
        .IsRequired();

    entity.HasOne(x => x.Patient)
        .WithMany()
        .HasForeignKey(x => x.PatientId)
        .OnDelete(DeleteBehavior.Cascade);
});
    }
}