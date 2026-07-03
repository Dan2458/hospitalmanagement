using HospitalManagement.Application.Features.Authentication.Commands.Login;
using HospitalManagement.Application.Features.Authentication.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterCommand command)
    {
        var success = await _mediator.Send(command);

        if (!success)
            return BadRequest(new
            {
                Message = "Registration failed."
            });

        return Ok(new
        {
            Message = "Registration successful."
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommand command)
    {
        var token = await _mediator.Send(command);

        if (token == null)
            return Unauthorized(new
            {
                Message = "Invalid email or password."
            });

        return Ok(new
        {
            Token = token
        });
    }
}