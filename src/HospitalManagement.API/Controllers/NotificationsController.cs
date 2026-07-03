using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// Explicitly pulling in the exact namespace paths we just verified
using HospitalManagement.Application.Features.Notifications.Commands.CreateNotification;
using HospitalManagement.Application.Features.Notifications.Commands.MarkNotificationAsRead;
using HospitalManagement.Application.Features.Notifications.Commands.DeleteNotification;
using HospitalManagement.Application.Features.Notifications.Queries.GetMyNotifications;

namespace HospitalManagement.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public NotificationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // ============================================
    // CREATE NOTIFICATION
    // ============================================
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateNotificationCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(
            nameof(GetMyNotifications),
            new { id },
            new
            {
                Message = "Notification created successfully.",
                NotificationId = id
            });
    }

    // ============================================
    // GET MY NOTIFICATIONS
    // ============================================
    [HttpGet]
    public async Task<IActionResult> GetMyNotifications()
    {
        var userId = Guid.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var notifications =
            await _mediator.Send(new GetMyNotificationsQuery(userId));

        return Ok(notifications);
    }

    // ============================================
    // MARK AS READ
    // ============================================
    [HttpPut("{id:guid}/read")]
    public async Task<IActionResult> MarkAsRead(Guid id)
    {
        var result = await _mediator.Send(
            new MarkNotificationAsReadCommand(id));

        if (!result)
        {
            return NotFound(new
            {
                Message = "Notification not found."
            });
        }

        return Ok(new
        {
            Message = "Notification marked as read."
        });
    }

    // ============================================
    // DELETE NOTIFICATION
    // ============================================
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(
            new DeleteNotificationCommand(id));

        if (!result)
        {
            return NotFound(new
            {
                Message = "Notification not found."
            });
        }

        return NoContent();
    }

    // ============================================
    // GET UNREAD COUNT
    // ============================================
    [HttpGet("unread-count")]
    public async Task<IActionResult> GetUnreadCount()
    {
        var userId = Guid.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var notifications =
            await _mediator.Send(new GetMyNotificationsQuery(userId));

        var count = notifications.Count(x => !x.IsRead);

        return Ok(new
        {
            UnreadCount = count
        });
    }
}