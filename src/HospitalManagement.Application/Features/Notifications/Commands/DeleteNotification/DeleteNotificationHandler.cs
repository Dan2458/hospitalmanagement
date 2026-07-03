using HospitalManagement.Application.Interfaces.Repositories;
using MediatR;

namespace HospitalManagement.Application.Features.Notifications.Commands.DeleteNotification;

public class DeleteNotificationHandler
    : IRequestHandler<DeleteNotificationCommand, bool>
{
    private readonly INotificationRepository _repository;

    public DeleteNotificationHandler(INotificationRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteNotificationCommand request,
        CancellationToken cancellationToken)
    {
        var notification = await _repository.GetByIdAsync(request.NotificationId);

        if (notification == null)
            return false;

        await _repository.DeleteAsync(notification);

        return true;
    }
}