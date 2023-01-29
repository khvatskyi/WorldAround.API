using Microsoft.AspNetCore.Http;
using WorldAround.Domain.Models.Events;
using WorldAround.Domain.Models.Paging;

namespace WorldAround.Application.Interfaces.Application;

public interface IEventsService
{
    Task<GetEventsPageModel> GetEvents(GetEventsParams @params, GetPageModel page);

    Task<EventDetailsModel> GetEvent(int id);

    Task UpdateImageAsync(int eventId, IFormFile image);

    Task<EventDetailsModel> CreateEvent(CreateEventModel model);

    Task DeleteEvent(int id);

    Task<EventDetailsModel> UpdateEvent(UpdateEventModel model);
}
