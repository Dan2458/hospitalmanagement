using HospitalManagement.Application.Interfaces.Repositories;
using MediatR;

namespace HospitalManagement.Application.Features.Notifications.Commands.MarkNotificationAsRead;

public class MarkNotificationAsReadHandler
    : IRequestHandler<MarkNotificationAsReadCommand, bool>
{
    private readonly INotificationRepository _repository;

    public MarkNotificationAsReadHandler(INotificationRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        MarkNotificationAsReadCommand request,
        CancellationToken cancellationToken)
    {
        var notification = await _repository.GetByIdAsync(request.NotificationId);

        if (notification == null)
            return false;

        notification.IsRead = true;

        await _repository.UpdateAsync(notification);

        return true;
    }
}