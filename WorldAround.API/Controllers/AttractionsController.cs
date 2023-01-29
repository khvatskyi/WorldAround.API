using Microsoft.AspNetCore.Mvc;
using WorldAround.Application.Interfaces.Application;
using WorldAround.Domain.Models.Attractions;

namespace WorldAround.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttractionsController : ControllerBase
{
    private readonly IAttractionsService _attractionsService;

    public AttractionsController(IAttractionsService attractionsService)
    {
        _attractionsService = attractionsService;
    }

    [HttpGet]
    public async Task<ActionResult<GetAttractionsModel>> GetAttractions([FromQuery] GetAttractionsParams @params,
        CancellationToken cancellationToken)
    {
        var attractions = await _attractionsService.GetAttractionsAsync(@params, cancellationToken);

        return Ok(attractions);
    }

    [HttpGet("{attractionId:int}")]
    public async Task<ActionResult<GetAttractionModel>> GetAttraction(int attractionId,
        CancellationToken cancellationToken)
    {
        var result = await _attractionsService.GetAttractionAsync(attractionId, cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> CreateAttraction([FromForm] CreateAttractionModel createAttractionModel)
    {
        await _attractionsService.CreateAttractionAsync(createAttractionModel);

        return Ok();
    }
}