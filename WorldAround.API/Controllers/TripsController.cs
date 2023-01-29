using Microsoft.AspNetCore.Mvc;
using WorldAround.Application.Interfaces.Application;
using WorldAround.Domain.Models.Trips;

namespace WorldAround.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    private readonly ITripsService _tripService;

    public TripsController(ITripsService tripService)
    {
        _tripService = tripService;
    }

    [HttpGet("{tripId:int}")]
    public async Task<ActionResult<GetTripsModel>> GetTrip(int tripId, CancellationToken cancellationToken)
    {
        var trip = await _tripService.GetTripAsync(tripId, cancellationToken);

        return Ok(trip);
    }

    [HttpGet]
    public async Task<ActionResult<GetTripsModel>> GetTrips([FromQuery] GetTripsParams @params,
        CancellationToken cancellationToken)
    {
        var trips = await _tripService.GetTripsAsync(@params, cancellationToken);

        return Ok(trips);
    }

    [HttpPost]
    public async Task<ActionResult> CreateTrip(CreateTripModel model)
    {
        await _tripService.CreateTripAsync(model);

        return Ok();
    }

    [HttpPut("Name")]
    public async Task<ActionResult> UpdateTripName(UpdateTripModel model)
    {
        await _tripService.UpdateTripNameAsync(model);

        return Ok();
    }

    [HttpPut("Description")]
    public async Task<ActionResult> UpdateTripDescription(UpdateTripModel model)
    {
        await _tripService.UpdateTripDescriptionAsync(model);

        return Ok();
    }

    [HttpDelete("{tripId:int}")]
    public async Task<ActionResult> DeleteTrip(int tripId)
    {
        await _tripService.DeleteTripAsync(tripId);

        return Ok();
    }
}