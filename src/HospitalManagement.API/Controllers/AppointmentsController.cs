// using HospitalManagement.Application.Features.Appointments.Commands.CreateAppointment;
// using MediatR;
// using Microsoft.AspNetCore.Mvc;

// namespace HospitalManagement.API.Controllers;
// using HospitalManagement.Application.Features.Appointments.Queries.GetAllAppointments;
// using HospitalManagement.Application.Features.Appointments.Queries.GetAppointmentById;
// using HospitalManagement.Application.Features.Appointments.Commands.CompleteAppointment;
// using HospitalManagement.Application.Features.Appointments.Commands.DeleteAppointment;
// [ApiController]
// [Route("api/[controller]")]
// public class AppointmentsController : ControllerBase
// {
//     private readonly IMediator _mediator;

//     public AppointmentsController(IMediator mediator)
//     {
//         _mediator = mediator;
//     }

//     [HttpPost]
//     public async Task<IActionResult> Create(
//         [FromBody] CreateAppointmentCommand command)
//     {
//         var id = await _mediator.Send(command);

//         return Ok(new
//         {
//             Message = "Appointment booked successfully.",
//             AppointmentId = id
//         });
//     }
//     [HttpGet]
// public async Task<IActionResult> GetAll()
// {
//     var appointments = await _mediator.Send(
//         new GetAllAppointmentsQuery());

//     return Ok(appointments);
// }
// [HttpGet("{id:guid}")]
// public async Task<IActionResult> GetById(Guid id)
// {
//     var appointment = await _mediator.Send(
//         new GetAppointmentByIdQuery(id));

//     if (appointment is null)
//     {
//         return NotFound(new
//         {
//             Message = "Appointment not found."
//         });
//     }

//     return Ok(appointment);
// }
// [HttpPut("{id:guid}/complete")]
// public async Task<IActionResult> Complete(Guid id)
// {
//     var result = await _mediator.Send(
//         new CompleteAppointmentCommand(id));

//     if (!result)
//     {
//         return NotFound(new
//         {
//             Message = "Appointment not found."
//         });
//     }

//     return Ok(new
//     {
//         Message = "Appointment completed successfully."
//     });
// }
// [HttpDelete("{id:guid}")]
// public async Task<IActionResult> Delete(Guid id)
// {
//     var result = await _mediator.Send(
//         new DeleteAppointmentCommand(id));

//     if (!result)
//     {
//         return NotFound(new
//         {
//             Message = "Appointment not found."
//         });
//     }

//     return NoContent();
// }
// }



using HospitalManagement.Application.Features.Appointments.Commands.CreateAppointment;
using HospitalManagement.Application.Features.Appointments.Queries.GetAllAppointments;
using HospitalManagement.Application.Features.Appointments.Queries.GetAppointmentById;
using HospitalManagement.Application.Features.Appointments.Commands.CompleteAppointment;
using HospitalManagement.Application.Features.Appointments.Commands.DeleteAppointment;
using HospitalManagement.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppointmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = Roles.Admin + "," + Roles.Receptionist)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAppointmentCommand command)
    {
        var id = await _mediator.Send(command);

        return Ok(new
        {
            Message = "Appointment booked successfully.",
            AppointmentId = id
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var appointments = await _mediator.Send(new GetAllAppointmentsQuery());
        return Ok(appointments);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var appointment = await _mediator.Send(new GetAppointmentByIdQuery(id));

        if (appointment is null)
            return NotFound(new { Message = "Appointment not found." });

        return Ok(appointment);
    }

    [HttpPut("{id:guid}/complete")]
    public async Task<IActionResult> Complete(Guid id)
    {
        var result = await _mediator.Send(new CompleteAppointmentCommand(id));

        if (!result)
            return NotFound(new { Message = "Appointment not found." });

        return Ok(new { Message = "Appointment completed successfully." });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteAppointmentCommand(id));

        if (!result)
            return NotFound(new { Message = "Appointment not found." });

        return NoContent();
    }
}