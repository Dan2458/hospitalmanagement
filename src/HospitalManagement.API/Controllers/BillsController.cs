// using HospitalManagement.Application.Features.Bills.Commands.CreateBill;
// using HospitalManagement.Application.Features.Bills.Commands.DeleteBill;
// using HospitalManagement.Application.Features.Bills.Commands.MarkBillAsPaid;
// using HospitalManagement.Application.Features.Bills.Queries.GetAllBills;
// using HospitalManagement.Application.Features.Bills.Queries.GetBillById;
// using MediatR;
// using Microsoft.AspNetCore.Mvc;

// namespace HospitalManagement.API.Controllers;

// [ApiController]
// [Route("api/[controller]")]
// public class BillsController : ControllerBase
// {
//     private readonly IMediator _mediator;

//     public BillsController(IMediator mediator)
//     {
//         _mediator = mediator;
//     }

//     // ===========================
//     // CREATE BILL
//     // ===========================
//     [HttpPost]
//     public async Task<IActionResult> Create(
//         [FromBody] CreateBillCommand command)
//     {
//         var id = await _mediator.Send(command);

//         return CreatedAtAction(
//             nameof(GetById),
//             new { id },
//             new
//             {
//                 Message = "Bill created successfully.",
//                 BillId = id
//             });
//     }

//     // ===========================
//     // GET ALL
//     // ===========================
//     [HttpGet]
//     public async Task<IActionResult> GetAll()
//     {
//         var bills = await _mediator.Send(new GetAllBillsQuery());

//         return Ok(bills);
//     }

//     // ===========================
//     // GET BY ID
//     // ===========================
//     [HttpGet("{id:guid}")]
//     public async Task<IActionResult> GetById(Guid id)
//     {
//         var bill = await _mediator.Send(new GetBillByIdQuery(id));

//         if (bill is null)
//         {
//             return NotFound(new
//             {
//                 Message = "Bill not found."
//             });
//         }

//         return Ok(bill);
//     }

//     // ===========================
//     // MARK AS PAID
//     // ===========================
//     [HttpPut("{id:guid}/pay")]
//     public async Task<IActionResult> Pay(Guid id)
//     {
//         var paid = await _mediator.Send(
//             new MarkBillAsPaidCommand(id));

//         if (!paid)
//         {
//             return NotFound(new
//             {
//                 Message = "Bill not found."
//             });
//         }

//         return Ok(new
//         {
//             Message = "Bill paid successfully."
//         });
//     }

//     // ===========================
//     // DELETE
//     // ===========================
//     [HttpDelete("{id:guid}")]
//     public async Task<IActionResult> Delete(Guid id)
//     {
//         var deleted = await _mediator.Send(
//             new DeleteBillCommand(id));

//         if (!deleted)
//         {
//             return NotFound(new
//             {
//                 Message = "Bill not found."
//             });
//         }

//         return NoContent();
//     }
// }



using HospitalManagement.Application.Features.Bills.Commands.CreateBill;
using HospitalManagement.Application.Features.Bills.Commands.DeleteBill;
using HospitalManagement.Application.Features.Bills.Commands.MarkBillAsPaid;
using HospitalManagement.Application.Features.Bills.Queries.GetAllBills;
using HospitalManagement.Application.Features.Bills.Queries.GetBillById;
using HospitalManagement.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BillsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BillsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = Roles.Admin + "," + Roles.Receptionist)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBillCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id }, new
        {
            Message = "Bill created successfully.",
            BillId = id
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var bills = await _mediator.Send(new GetAllBillsQuery());
        return Ok(bills);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var bill = await _mediator.Send(new GetBillByIdQuery(id));

        if (bill is null)
            return NotFound(new { Message = "Bill not found." });

        return Ok(bill);
    }

    [Authorize(Roles = Roles.Admin + "," + Roles.Receptionist)]
    [HttpPut("{id:guid}/pay")]
    public async Task<IActionResult> Pay(Guid id)
    {
        var paid = await _mediator.Send(new MarkBillAsPaidCommand(id));

        if (!paid)
            return NotFound(new { Message = "Bill not found." });

        return Ok(new { Message = "Bill paid successfully." });
    }

    [Authorize(Roles = Roles.Admin + "," + Roles.Receptionist)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _mediator.Send(new DeleteBillCommand(id));

        if (!deleted)
            return NotFound(new { Message = "Bill not found." });

        return NoContent();
    }
}