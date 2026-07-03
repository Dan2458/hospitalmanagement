using MediatR;

namespace HospitalManagement.Application.Features.Notifications.Commands.DeleteNotification;

public record DeleteNotificationCommand(Guid NotificationId)
    : IRequest<bool>;