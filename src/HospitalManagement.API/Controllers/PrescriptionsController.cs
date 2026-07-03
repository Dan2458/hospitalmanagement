// using HospitalManagement.Application.Features.Prescriptions.Commands.CreatePrescription;
// using MediatR;
// using Microsoft.AspNetCore.Mvc;
// using HospitalManagement.Application.Features.Prescriptions.Queries.GetAllPrescriptions;
// using HospitalManagement.Application.Features.Prescriptions.Queries.GetPrescriptionById;
// namespace HospitalManagement.API.Controllers;
// using HospitalManagement.Application.Features.Prescriptions.Commands.UpdatePrescription;
// using HospitalManagement.Application.Features.Prescriptions.Commands.DeletePrescription;

// [ApiController]
// [Route("api/[controller]")]
// public class PrescriptionsController : ControllerBase
// {
//     private readonly IMediator _mediator;

//     public PrescriptionsController(IMediator mediator)
//     {
//         _mediator = mediator;
//     }

//     [HttpPost]
//     public async Task<IActionResult> Create(
//         CreatePrescriptionCommand command)
//     {
//         var id = await _mediator.Send(command);

//         return CreatedAtAction(
//             nameof(Create),
//             new { id },
//             new
//             {
//                 Message = "Prescription created successfully.",
//                 PrescriptionId = id
//             });
//     }
//     [HttpGet]
// public async Task<IActionResult> GetAll()
// {
//     return Ok(await _mediator.Send(new GetAllPrescriptionsQuery()));
// }

// [HttpGet("{id:guid}")]
// public async Task<IActionResult> GetById(Guid id)
// {
//     var prescription =
//         await _mediator.Send(new GetPrescriptionByIdQuery(id));

//     if (prescription is null)
//         return NotFound();

//     return Ok(prescription);
// }
// [HttpPut]
// public async Task<IActionResult> Update(UpdatePrescriptionCommand command)
// {
//     await _mediator.Send(command);

//     return Ok(new
//     {
//         Message = "Prescription updated successfully."
//     });
// }

// [HttpDelete("{id:guid}")]
// public async Task<IActionResult> Delete(Guid id)
// {
//     await _mediator.Send(new DeletePrescriptionCommand(id));

//     return NoContent();
// }
// }




using HospitalManagement.Application.Features.Prescriptions.Commands.CreatePrescription;
using HospitalManagement.Application.Features.Prescriptions.Queries.GetAllPrescriptions;
using HospitalManagement.Application.Features.Prescriptions.Queries.GetPrescriptionById;
using HospitalManagement.Application.Features.Prescriptions.Commands.UpdatePrescription;
using HospitalManagement.Application.Features.Prescriptions.Commands.DeletePrescription;
using HospitalManagement.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers;

[Authorize(Roles = Roles.Doctor)]
[ApiController]
[Route("api/[controller]")]
public class PrescriptionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PrescriptionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePrescriptionCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id }, new
        {
            Message = "Prescription created successfully.",
            PrescriptionId = id
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllPrescriptionsQuery()));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var prescription = await _mediator.Send(new GetPrescriptionByIdQuery(id));

        if (prescription is null)
            return NotFound(new { Message = "Prescription not found." });

        return Ok(prescription);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePrescriptionCommand command)
    {
        await _mediator.Send(command);

        return Ok(new { Message = "Prescription updated successfully." });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeletePrescriptionCommand(id));
        return NoContent();
    }
}