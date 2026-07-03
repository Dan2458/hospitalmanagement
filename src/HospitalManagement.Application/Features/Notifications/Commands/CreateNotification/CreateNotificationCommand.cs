using MediatR;

namespace HospitalManagement.Application.Features.Notifications.Commands.CreateNotification;

public record CreateNotificationCommand(Guid UserId, string Message) : IRequest<Guid>;