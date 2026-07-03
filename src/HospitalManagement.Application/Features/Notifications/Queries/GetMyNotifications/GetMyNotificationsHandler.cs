using HospitalManagement.Application.Interfaces.Repositories;
using MediatR;

namespace HospitalManagement.Application.Features.Notifications.Queries.GetMyNotifications;

public class GetMyNotificationsHandler : IRequestHandler<GetMyNotificationsQuery, List<NotificationDto>>
{
    private readonly INotificationRepository _notificationRepository;

    public GetMyNotificationsHandler(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<List<NotificationDto>> Handle(GetMyNotificationsQuery request, CancellationToken cancellationToken)
    {
        // Uses the exact GetByUserAsync from your interface
        var notifications = await _notificationRepository.GetByUserAsync(request.UserId);

        return notifications.Select(n => new NotificationDto 
        {
            Id = n.Id,
            Message = n.Message,
            IsRead = n.IsRead,
            CreatedAt = n.CreatedAt
        }).ToList();
    }
}