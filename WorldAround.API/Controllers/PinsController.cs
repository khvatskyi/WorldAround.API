using Microsoft.AspNetCore.Mvc;
using WorldAround.Application.Interfaces.Application;
using WorldAround.Domain.Models.Pins;

namespace WorldAround.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PinsController : ControllerBase
{
    private readonly IPinsService _pinsService;

    public PinsController(IPinsService pinsService)
    {
        _pinsService = pinsService;
    }

    [HttpPut]
    public async Task<ActionResult> UpdatePin(UpdatePinModel model)
    {
        await _pinsService.UpdatePinAsync(model);

        return Ok();
    }
}