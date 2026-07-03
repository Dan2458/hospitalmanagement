// using HospitalManagement.Application.Features.LabTests.Commands.CreateLabTest;
// using HospitalManagement.Application.Features.LabTests.Commands.CompleteLabTest;
// using HospitalManagement.Application.Features.LabTests.Commands.DeleteLabTest;
// using HospitalManagement.Application.Features.LabTests.Queries.GetAllLabTests;
// using HospitalManagement.Application.Features.LabTests.Queries.GetLabTestById;
// using MediatR;
// using Microsoft.AspNetCore.Mvc;

// namespace HospitalManagement.API.Controllers;

// [ApiController]
// [Route("api/[controller]")]
// public class LabTestsController : ControllerBase
// {
//     private readonly IMediator _mediator;

//     public LabTestsController(IMediator mediator)
//     {
//         _mediator = mediator;
//     }

//     [HttpPost]
//     public async Task<IActionResult> Create(CreateLabTestCommand command)
//     {
//         var id = await _mediator.Send(command);

//         return Ok(new
//         {
//             Message = "Lab test requested successfully.",
//             LabTestId = id
//         });
//     }

//     [HttpGet]
//     public async Task<IActionResult> GetAll()
//     {
//         return Ok(await _mediator.Send(new GetAllLabTestsQuery()));
//     }

//     [HttpGet("{id:guid}")]
//     public async Task<IActionResult> Get(Guid id)
//     {
//         var result = await _mediator.Send(new GetLabTestByIdQuery(id));

//         if (result == null)
//             return NotFound();

//         return Ok(result);
//     }

//     [HttpPut("complete")]
//     public async Task<IActionResult> Complete(CompleteLabTestCommand command)
//     {
//         await _mediator.Send(command);

//         return Ok(new
//         {
//             Message = "Lab test completed successfully."
//         });
//     }

//     [HttpDelete("{id:guid}")]
//     public async Task<IActionResult> Delete(Guid id)
//     {
//         await _mediator.Send(new DeleteLabTestCommand(id));

//         return NoContent();
//     }
// }



using HospitalManagement.Application.Features.LabTests.Commands.CreateLabTest;
using HospitalManagement.Application.Features.LabTests.Commands.CompleteLabTest;
using HospitalManagement.Application.Features.LabTests.Commands.DeleteLabTest;
using HospitalManagement.Application.Features.LabTests.Queries.GetAllLabTests;
using HospitalManagement.Application.Features.LabTests.Queries.GetLabTestById;
using HospitalManagement.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers;

[Authorize(Roles = Roles.LabScientist)]
[ApiController]
[Route("api/[controller]")]
public class LabTestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LabTestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLabTestCommand command)
    {
        var id = await _mediator.Send(command);

        return Ok(new
        {
            Message = "Lab test requested successfully.",
            LabTestId = id
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllLabTestsQuery()));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _mediator.Send(new GetLabTestByIdQuery(id));

        if (result == null)
            return NotFound(new { Message = "Lab test not found." });

        return Ok(result);
    }

    [HttpPut("complete")]
    public async Task<IActionResult> Complete([FromBody] CompleteLabTestCommand command)
    {
        await _mediator.Send(command);

        return Ok(new { Message = "Lab test completed successfully." });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteLabTestCommand(id));
        return NoContent();
    }
}