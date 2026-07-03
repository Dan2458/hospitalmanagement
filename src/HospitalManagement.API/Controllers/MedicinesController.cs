using HospitalManagement.Application.Features.Medicines.Commands.CreateMedicine;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MedicinesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MedicinesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Admin,Pharmacist")]
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateMedicineCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(
            nameof(Create),
            new { id },
            new
            {
                Message = "Medicine created successfully.",
                MedicineId = id
            });
    }
}