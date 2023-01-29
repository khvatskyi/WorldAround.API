using Microsoft.AspNetCore.Mvc;
using WorldAround.Application.Interfaces.Application;
using WorldAround.Domain.Models.Identity;

namespace WorldAround.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authService;

    public AuthenticationController(IAuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> Authorize([FromBody] LoginModel loginModel)
    {
        var result = await _authService.AuthenticateAsync(loginModel);

        return result.Details.Succeeded ? Ok(result) : BadRequest(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RegistrationModel registrationModel)
    {
        var result = await _authService.CreateAsync(registrationModel);

        return result.Succeeded ? Ok(result) : BadRequest(result.Errors);
    }
}
