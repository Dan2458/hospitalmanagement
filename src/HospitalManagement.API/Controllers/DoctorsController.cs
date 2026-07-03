// using HospitalManagement.Application.Features.Doctors.Commands.CreateDoctor;
// using HospitalManagement.Application.Features.Doctors.Commands.DeleteDoctor;
// using HospitalManagement.Application.Features.Doctors.Commands.UpdateDoctor;
// using HospitalManagement.Application.Features.Doctors.Queries.GetAllDoctors;
// using HospitalManagement.Application.Features.Doctors.Queries.GetDoctorById;
// using HospitalManagement.Domain.Constants;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;

// namespace HospitalManagement.API.Controllers;

// [Authorize]
// [ApiController]
// [Route("api/[controller]")]
// public class DoctorsController : ControllerBase
// {
//     private readonly IMediator _mediator;

//     public DoctorsController(IMediator mediator)
//     {
//         _mediator = mediator;
//     }

//     // Admin can create doctors
//     [Authorize(Roles = Roles.Admin)]
//     [HttpPost]
//     public async Task<IActionResult> Create([FromBody] CreateDoctorCommand command)
//     {
//         var id = await _mediator.Send(command);

//         return CreatedAtAction(nameof(GetById), new { id }, new
//         {
//             Message = "Doctor created successfully.",
//             DoctorId = id
//         });
//     }

//     // Admin and Doctors can view all doctors
//     [Authorize(Roles = Roles.Admin + "," + Roles.Doctor)]
//     [HttpGet]
//     public async Task<IActionResult> GetAll()
//     {
//         var doctors = await _mediator.Send(new GetAllDoctorsQuery());

//         return Ok(doctors);
//     }

//     // Admin and Doctors can view a doctor
//     [Authorize(Roles = Roles.Admin + "," + Roles.Doctor)]
//     [HttpGet("{id:guid}")]
//     public async Task<IActionResult> GetById(Guid id)
//     {
//         var doctor = await _mediator.Send(new GetDoctorByIdQuery(id));

//         if (doctor is null)
//         {
//             return NotFound(new
//             {
//                 Message = "Doctor not found."
//             });
//         }

//         return Ok(doctor);
//     }

//     // Only Admin can update doctors
//     [Authorize(Roles = Roles.Admin)]
//     [HttpPut("{id:guid}")]
//     public async Task<IActionResult> Update(
//         Guid id,
//         [FromBody] UpdateDoctorCommand command)
//     {
//         if (id != command.Id)
//         {
//             return BadRequest(new
//             {
//                 Message = "Route ID and request ID do not match."
//             });
//         }

//         var updated = await _mediator.Send(command);

//         if (!updated)
//         {
//             return NotFound(new
//             {
//                 Message = "Doctor not found."
//             });
//         }

//         return Ok(new
//         {
//             Message = "Doctor updated successfully."
//         });
//     }

//     // Only Admin can delete doctors
//     [Authorize(Roles = Roles.Admin)]
//     [HttpDelete("{id:guid}")]
//     public async Task<IActionResult> Delete(Guid id)
//     {
//         var deleted = await _mediator.Send(new DeleteDoctorCommand(id));

//         if (!deleted)
//         {
//             return NotFound(new
//             {
//                 Message = "Doctor not found."
//             });
//         }

//         return NoContent();
//     }
// }







using HospitalManagement.Application.Features.Doctors.Commands.CreateDoctor;
using HospitalManagement.Application.Features.Doctors.Commands.DeleteDoctor;
using HospitalManagement.Application.Features.Doctors.Commands.UpdateDoctor;
using HospitalManagement.Application.Features.Doctors.Queries.GetAllDoctors;
using HospitalManagement.Application.Features.Doctors.Queries.GetDoctorById;
using HospitalManagement.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class DoctorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDoctorCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id }, new
        {
            Message = "Doctor created successfully.",
            DoctorId = id
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var doctors = await _mediator.Send(new GetAllDoctorsQuery());
        return Ok(doctors);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var doctor = await _mediator.Send(new GetDoctorByIdQuery(id));

        if (doctor is null)
            return NotFound(new { Message = "Doctor not found." });

        return Ok(doctor);
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDoctorCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { Message = "Route ID and request ID do not match." });

        var updated = await _mediator.Send(command);

        if (!updated)
            return NotFound(new { Message = "Doctor not found." });

        return Ok(new { Message = "Doctor updated successfully." });
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _mediator.Send(new DeleteDoctorCommand(id));

        if (!deleted)
            return NotFound(new { Message = "Doctor not found." });

        return NoContent();
    }
}