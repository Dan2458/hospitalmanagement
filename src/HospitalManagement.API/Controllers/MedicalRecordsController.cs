// using HospitalManagement.Application.Features.MedicalRecords.Commands.CreateMedicalRecord;
// using MediatR;
// using Microsoft.AspNetCore.Mvc;
// using HospitalManagement.Application.Features.MedicalRecords.Queries.GetAllMedicalRecords;
// namespace HospitalManagement.API.Controllers;
// using HospitalManagement.Application.Features.MedicalRecords.Queries.GetMedicalRecordById;
// using HospitalManagement.Application.Features.MedicalRecords.Commands.UpdateMedicalRecord;
// using HospitalManagement.Application.Features.MedicalRecords.Commands.DeleteMedicalRecord;
// using HospitalManagement.Application.Features.MedicalRecords.Queries.GetPatientMedicalHistory;

// [ApiController]
// [Route("api/[controller]")]
// public class MedicalRecordsController : ControllerBase
// {
//     private readonly IMediator _mediator;

//     public MedicalRecordsController(IMediator mediator)
//     {
//         _mediator = mediator;
//     }

//     [HttpPost]
//     public async Task<IActionResult> Create(
//         [FromBody] CreateMedicalRecordCommand command)
//     {
//         var id = await _mediator.Send(command);

//         return CreatedAtAction(
//             nameof(Create),
//             new { id },
//             new
//             {
//                 Message = "Medical record created successfully.",
//                 MedicalRecordId = id
//             });

            
//     }
//     [HttpGet]
// public async Task<IActionResult> GetAll()
// {
//     var records = await _mediator.Send(new GetAllMedicalRecordsQuery());

//     return Ok(records);
// }
// [HttpGet("{id:guid}")]
// public async Task<IActionResult> GetById(Guid id)
// {
//     var record = await _mediator.Send(new GetMedicalRecordByIdQuery(id));

//     if (record is null)
//         return NotFound();

//     return Ok(record);
// }
// [HttpPut("{id:guid}")]
// public async Task<IActionResult> Update(
//     Guid id,
//     UpdateMedicalRecordCommand command)
// {
//     if (id != command.Id)
//         return BadRequest();

//     await _mediator.Send(command);

//     return Ok(new
//     {
//         Message = "Medical record updated successfully."
//     });
// }

// [HttpDelete("{id:guid}")]
// public async Task<IActionResult> Delete(Guid id)
// {
//     await _mediator.Send(new DeleteMedicalRecordCommand(id));

//     return NoContent();
// }

// [HttpGet("patient/{patientId:guid}")]
// public async Task<IActionResult> GetPatientHistory(Guid patientId)
// {
//     var history = await _mediator.Send(
//         new GetPatientMedicalHistoryQuery(patientId));

//     return Ok(history);
// }
// }



using HospitalManagement.Application.Features.MedicalRecords.Commands.CreateMedicalRecord;
using HospitalManagement.Application.Features.MedicalRecords.Queries.GetAllMedicalRecords;
using HospitalManagement.Application.Features.MedicalRecords.Queries.GetMedicalRecordById;
using HospitalManagement.Application.Features.MedicalRecords.Commands.UpdateMedicalRecord;
using HospitalManagement.Application.Features.MedicalRecords.Commands.DeleteMedicalRecord;
using HospitalManagement.Application.Features.MedicalRecords.Queries.GetPatientMedicalHistory;
using HospitalManagement.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MedicalRecordsController : ControllerBase
{
    private readonly IMediator _mediator;

    public MedicalRecordsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = Roles.Doctor)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMedicalRecordCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id }, new
        {
            Message = "Medical record created successfully.",
            MedicalRecordId = id
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var records = await _mediator.Send(new GetAllMedicalRecordsQuery());
        return Ok(records);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var record = await _mediator.Send(new GetMedicalRecordByIdQuery(id));

        if (record is null)
            return NotFound(new { Message = "Medical record not found." });

        return Ok(record);
    }

    [Authorize(Roles = Roles.Doctor)]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMedicalRecordCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { Message = "Route ID and request ID do not match." });

        await _mediator.Send(command);

        return Ok(new { Message = "Medical record updated successfully." });
    }

    [Authorize(Roles = Roles.Doctor)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteMedicalRecordCommand(id));
        return NoContent();
    }

    [HttpGet("patient/{patientId:guid}")]
    public async Task<IActionResult> GetPatientHistory(Guid patientId)
    {
        var history = await _mediator.Send(new GetPatientMedicalHistoryQuery(patientId));
        return Ok(history);
    }
}