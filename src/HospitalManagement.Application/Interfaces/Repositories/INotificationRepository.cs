using HospitalManagement.Domain.Entities;

namespace HospitalManagement.Application.Interfaces.Repositories;

public interface INotificationRepository

{

Task AddAsync(Notification notification);

Task<List<Notification>> GetByUserAsync(Guid userId);

Task<int> GetUnreadCountAsync(Guid userId);

Task<Notification?> GetByIdAsync(Guid id);

Task UpdateAsync(Notification notification);

Task DeleteAsync(Notification notification);

}