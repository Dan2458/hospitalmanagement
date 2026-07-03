using HospitalManagement.Application.Interfaces.Repositories;
using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.Notifications.Commands.CreateNotification;

public class CreateNotificationHandler : IRequestHandler<CreateNotificationCommand, Guid>
{
    private readonly INotificationRepository _notificationRepository;

    public CreateNotificationHandler(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<Guid> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
    {
        var notification = new Notification
        {
            UserId = request.UserId,
            Message = request.Message,
            CreatedAt = DateTime.UtcNow,
            IsRead = false
        };

        // Uses the exact single-parameter AddAsync from your interface
        await _notificationRepository.AddAsync(notification);
        
        return notification.Id;
    }
}