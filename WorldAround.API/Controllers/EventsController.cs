using Microsoft.AspNetCore.Mvc;
using WorldAround.Application.Interfaces.Application;
using WorldAround.Domain.Models.Events;
using WorldAround.Domain.Models.Paging;

namespace WorldAround.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsService _service;

        public EventsController(IEventsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetEventsParams @params, [FromQuery] GetPageModel page)
        {
            return Ok(await _service.GetEvents(@params, page));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetEvent(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateEventModel @event)
        {
            return Ok(await _service.CreateEvent(@event));
        }

        [HttpPut("[action]/{eventId:int}"), DisableRequestSizeLimit]
        public async Task<IActionResult> UpdateEventImage(int eventId, [FromForm] IFormFile image)
        {
            await _service.UpdateImageAsync(eventId, image);

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateEventModel @event)
        {
            return @event.Id.Equals(id) ?
                Ok(await _service.UpdateEvent(@event)) :
                BadRequest("The Id's in the route parameter and the body are not same");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteEvent(id);

            return Ok();
        }
    }
}
