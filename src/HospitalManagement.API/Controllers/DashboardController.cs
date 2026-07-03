// // using HospitalManagement.Application.Features.Dashboard.Queries.GetDashboard;
// // using MediatR;
// // using Microsoft.AspNetCore.Mvc;

// // namespace HospitalManagement.API.Controllers;

// // [ApiController]
// // [Route("api/[controller]")]
// // public class DashboardController : ControllerBase
// // {
// //     private readonly IMediator _mediator;

// //     public DashboardController(IMediator mediator)
// //     {
// //         _mediator = mediator;
// //     }

// //     [HttpGet]
// //     public async Task<IActionResult> Get()
// //     {
// //         var dashboard =
// //             await _mediator.Send(new GetDashboardQuery());

// //         return Ok(dashboard);
// //     }
// // }


// using HospitalManagement.Application.Features.Dashboard.Queries.GetDashboard;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;

// namespace HospitalManagement.API.Controllers;

// [Authorize]
// [ApiController]
// [Route("api/[controller]")]
// public class DashboardController : ControllerBase
// {
//     private readonly IMediator _mediator;

//     public DashboardController(IMediator mediator)
//     {
//         _mediator = mediator;
//     }

//     [HttpGet]
//     public async Task<IActionResult> Get()
//     {
//         var dashboard = await _mediator.Send(new GetDashboardQuery());

//         return Ok(dashboard);
//     }
// }



using HospitalManagement.Application.Features.Dashboard.Queries.GetDashboardStatistics;
using HospitalManagement.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DashboardController : ControllerBase
{
    private readonly IMediator _mediator;

    public DashboardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpGet]
    public async Task<IActionResult> GetDashboard()
    {
        var dashboard = await _mediator.Send(
            new GetDashboardStatisticsQuery());

        return Ok(dashboard);
    }
}