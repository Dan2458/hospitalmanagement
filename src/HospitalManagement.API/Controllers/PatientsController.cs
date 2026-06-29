using HospitalManagement.Application.Features.Patients.Commands.CreatePatient;
using HospitalManagement.Application.Features.Patients.Queries.GetAllPatients;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HospitalManagement.Application.Features.Patients.Queries.GetPatientById;
namespace HospitalManagement.API.Controllers;
using HospitalManagement.Application.Features.Patients.Commands.UpdatePatient;
using HospitalManagement.Application.Features.Patients.Commands.DeletePatient;
using HospitalManagement.Application.Features.Patients.Commands.AdmitPatient;
using HospitalManagement.Application.Features.Patients.Commands.DischargePatient;
using HospitalManagement.Application.Features.Patients.Commands.AddBill;
using HospitalManagement.Application.Features.Patients.Commands.PayBill;
[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePatientCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetAll), new { id }, new
        {
            Message = "Patient created successfully.",
            PatientId = id
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var patients = await _mediator.Send(new GetAllPatientsQuery());

        return Ok(patients);
    }

    [HttpGet("{id:guid}")]
public async Task<IActionResult> GetById(Guid id)
{
    var patient = await _mediator.Send(new GetPatientByIdQuery(id));

    if (patient is null)
        return NotFound(new
        {
            Message = "Patient not found."
        });

    return Ok(patient);
}

[HttpPut("{id:guid}")]
public async Task<IActionResult> Update(
    Guid id,
    [FromBody] UpdatePatientCommand command)
{
    if (id != command.Id)
        return BadRequest(new
        {
            Message = "Route ID and request ID do not match."
        });

    var updated = await _mediator.Send(command);

    if (!updated)
        return NotFound(new
        {
            Message = "Patient not found."
        });

    return Ok(new
    {
        Message = "Patient updated successfully."
    });
}

[HttpDelete("{id:guid}")]
public async Task<IActionResult> Delete(Guid id)
{
    var deleted = await _mediator.Send(new DeletePatientCommand(id));

    if (!deleted)
    {
        return NotFound(new
        {
            Message = "Patient not found."
        });
    }

    return NoContent();
}

[HttpPost("{id:guid}/admit")]
public async Task<IActionResult> Admit(Guid id)
{
    var admitted = await _mediator.Send(new AdmitPatientCommand(id));

    if (!admitted)
    {
        return NotFound(new
        {
            Message = "Patient not found."
        });
    }

    return Ok(new
    {
        Message = "Patient admitted successfully."
    });
}

[HttpPost("{id:guid}/discharge")]
public async Task<IActionResult> Discharge(Guid id)
{
    var discharged = await _mediator.Send(new DischargePatientCommand(id));

    if (!discharged)
    {
        return NotFound(new
        {
            Message = "Patient not found."
        });
    }

    return Ok(new
    {
        Message = "Patient discharged successfully."
    });
}
[HttpPost("{id:guid}/bill")]
public async Task<IActionResult> AddBill(
    Guid id,
    [FromBody] decimal amount)
{
    var result = await _mediator.Send(
        new AddBillCommand(id, amount));

    if (!result)
        return NotFound(new
        {
            Message = "Patient not found."
        });

    return Ok(new
    {
        Message = "Bill added successfully."
    });
}
[HttpPost("{id:guid}/payment")]
public async Task<IActionResult> PayBill(
    Guid id,
    [FromBody] decimal amount)
{
    var result = await _mediator.Send(
        new PayBillCommand(id, amount));

    if (!result)
    {
        return NotFound(new
        {
            Message = "Patient not found."
        });
    }

    return Ok(new
    {
        Message = "Payment recorded successfully."
    });
}
}