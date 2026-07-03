using MediatR;

namespace HospitalManagement.Application.Features.Notifications.Queries.GetMyNotifications;

public record GetMyNotificationsQuery(Guid UserId) : IRequest<List<NotificationDto>>;