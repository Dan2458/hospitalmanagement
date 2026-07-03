using HospitalManagement.Domain.Entities;

namespace HospitalManagement.Application.Interfaces;

public interface IAppointmentRepository
{
    Task<List<Appointment>> GetAllAsync();

    Task<Appointment?> GetByIdAsync(Guid id);

    Task AddAsync(Appointment appointment);

    Task UpdateAsync(Appointment appointment);

    Task DeleteAsync(Guid id);

    Task<bool> ExistsAsync(Guid doctorId, DateTime appointmentDate);
    Task<int> CountAsync();
    

    Task<int> CountCompletedAsync();
}