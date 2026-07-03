// using HospitalManagement.Application.Interfaces.Repositories;
// using HospitalManagement.Domain.Entities;
// using HospitalManagement.Infrastructure.Data;
// using Microsoft.EntityFrameworkCore;

// namespace HospitalManagement.Infrastructure.Repositories;

// public class NotificationRepository : INotificationRepository
// {
//     private readonly ApplicationDbContext _context;

//     public NotificationRepository(ApplicationDbContext context)
//     {
//         _context = context;
//     }

//     public async Task AddAsync(Notification notification)
//     {
//         _context.Notifications.Add(notification);
//         await _context.SaveChangesAsync();
//     }

//     public async Task<List<Notification>> GetByUserAsync(string userId)
//     {
//         return await _context.Notifications
//             .Where(x => x.UserId == userId)
//             .OrderByDescending(x => x.CreatedAt)
//             .ToListAsync();
//     }

//     public async Task<int> GetUnreadCountAsync(string userId)
//     {
//         return await _context.Notifications
//             .CountAsync(x => x.UserId == userId && !x.IsRead);
//     }

//     public async Task<Notification?> GetByIdAsync(Guid id)
//     {
//         return await _context.Notifications
//             .FirstOrDefaultAsync(x => x.Id == id);
//     }

//     public async Task UpdateAsync(Notification notification)
//     {
//         _context.Notifications.Update(notification);
//         await _context.SaveChangesAsync();
//     }

//     public async Task DeleteAsync(Notification notification)
//     {
//         _context.Notifications.Remove(notification);
//         await _context.SaveChangesAsync();
//     }
// }



using HospitalManagement.Application.Interfaces.Repositories;

using HospitalManagement.Domain.Entities;

using HospitalManagement.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Infrastructure.Repositories;

public class NotificationRepository : INotificationRepository

{

private readonly ApplicationDbContext _context;

public NotificationRepository(ApplicationDbContext context)

{

_context = context;

}

public async Task AddAsync(Notification notification)

{

_context.Notifications.Add(notification);

await _context.SaveChangesAsync();

}

public async Task<List<Notification>> GetByUserAsync(Guid userId)

{

return await _context.Notifications

.Where(x => x.UserId == userId)

.OrderByDescending(x => x.CreatedAt)

.ToListAsync();

}

public async Task<int> GetUnreadCountAsync(Guid userId)

{

return await _context.Notifications

.CountAsync(x => x.UserId == userId && !x.IsRead);

}

public async Task<Notification?> GetByIdAsync(Guid id)

{

return await _context.Notifications

.FirstOrDefaultAsync(x => x.Id == id);

}

public async Task UpdateAsync(Notification notification)

{

_context.Notifications.Update(notification);

await _context.SaveChangesAsync();

}

public async Task DeleteAsync(Notification notification)

{

_context.Notifications.Remove(notification);

await _context.SaveChangesAsync();

}

}