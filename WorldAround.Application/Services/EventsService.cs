using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WorldAround.Application.Interfaces.Application;
using WorldAround.Application.Interfaces.Infrastructure;
using WorldAround.Domain.Entities;
using WorldAround.Domain.Enums;
using WorldAround.Domain.Models.Events;
using WorldAround.Domain.Models.Paging;

namespace WorldAround.Application.Services;

public class EventsService : IEventsService
{
    private readonly IMapper _mapper;
    private readonly IWorldAroundDbContext _context;
    private readonly IUsersService _usersService;
    private readonly IBlobStorageGateway _blobStorageGateway;
    private IQueryable<Event> Events => _context.Events.Where(e => e.Display);

    public EventsService(
        IMapper mapper,
        IWorldAroundDbContext context,
        IBlobStorageGateway blobStorageGateway,
        IUsersService usersService)
    {
        _mapper = mapper;
        _context = context;
        _blobStorageGateway = blobStorageGateway;
        _usersService = usersService;
    }

    public async Task<GetEventsPageModel> GetEvents(GetEventsParams @params, GetPageModel page)
    {
        var queryEvents = Events;

        if (@params.UserId != null)
        {
            queryEvents = queryEvents.Where(e => e.Participants.Any(p => p.UserId.Equals(@params.UserId)));

            if (@params.IsOwner != null)
            {
                if (@params.IsOwner == true)
                {
                    queryEvents = queryEvents.Where(e =>
                        e.Participants.Any(p =>
                            p.UserId.Equals(@params.UserId) &&
                            p.ParticipantRoleId.Equals(ParticipantRoleProfile.Owner)));
                }
                else
                {
                    queryEvents = queryEvents.Where(e =>
                        e.Participants.Any(p =>
                            p.UserId.Equals(@params.UserId) &&
                            p.ParticipantRoleId != ParticipantRoleProfile.Owner));
                }
            }
        }

        if (@params.Accessibility != null)
        {
            queryEvents = queryEvents.Where(e => @params.Accessibility.Equals(e.AccessibilityId));
        }

        if (!string.IsNullOrWhiteSpace(@params.SearchValue))
        {
            var value = @params.SearchValue.ToUpper();

            queryEvents = queryEvents.Where(e =>
                e.Title.ToUpper().Contains(value) || e.Description.ToUpper().Contains(value));
        }

        var count = await queryEvents.CountAsync();

        page.PageIndex = page.PageIndex < 0 ? 0 : page.PageIndex;
        page.PageSize = page.PageSize < 0 ? 0 : page.PageSize;

        var totalPages = page.PageSize != 0 ? (int)Math.Ceiling((double)count / page.PageSize) : 0;

        var events = await queryEvents.Skip(page.PageIndex * page.PageSize)
            .Take(page.PageSize)
            .Include(e => e.Participants.Where(x => x.ParticipantRoleId == ParticipantRoleProfile.Owner))
            .ToListAsync();

        var eventsPage = new GetEventsPageModel
        {
            Events = _mapper.Map<List<GetEventModel>>(events),
            PageInfo = new PagingModel
            {
                PageIndex = page.PageIndex,
                PageSize = page.PageSize,
                TotalPages = totalPages,
                Length = count
            }
        };

        for (int i = 0; i < events.Count; i++)
        {
            var eventOwner = events[i].Participants.Find(p => p.ParticipantRoleId == ParticipantRoleProfile.Owner);

            if (eventOwner != null)
            {
                eventsPage.Events[i].Author = await _usersService.GetAsync(eventOwner.UserId);
            }
        }

        return eventsPage;
    }

    public async Task<EventDetailsModel> GetEvent(int id)
    {
        var @event = await Events.Include(e => e.AttractionEventLinks)
            .ThenInclude(e => e.Attraction)
            .Include(e => e.TripEventLinks)
            .ThenInclude(e => e.Trip)
            .Include(e => e.Participants)
            .ThenInclude(e => e.User)
            .Include(e => e.Chats)
            .ThenInclude(e => e.Messages)
            .FirstOrDefaultAsync(e => e.Id.Equals(id));

        var model = _mapper.Map<EventDetailsModel>(@event);

        return model;
    }

    public async Task UpdateImageAsync(int eventId, IFormFile image)
    {
        var @event = await _context.Events.FirstOrDefaultAsync(e => e.Id.Equals(eventId));

        if (@event == null)
        {
            throw new InvalidOperationException("Event not found to update its image");
        }

        var blobName = $"Event{eventId}_{DateTime.Now.ToFileTime()}_{image.FileName}";
        await _blobStorageGateway.UploadImageAsync(blobName, image);

        @event.ImagePath = blobName;
        await _context.SaveChangesAsync();
    }

    public async Task<EventDetailsModel> CreateEvent(CreateEventModel model)
    {
        var @event = _mapper.Map<Event>(model);

        await _context.Events.AddAsync(@event);
        await _context.SaveChangesAsync();

        @event.Participants = new List<Participant>
        {
            new()
            {
                EventId = @event.Id,
                UserId = model.CreateUserId,
                ParticipantRoleId = ParticipantRoleProfile.Owner
            }
        };

        if (model.Places != null || model.Participants != null)
        {
            @event.TripEventLinks = new List<TripEventLink>();
            @event.AttractionEventLinks = new List<AttractionEventLink>();

            model.Places?.ForEach(item =>
            {
                switch (item.PlaceType)
                {
                    case PlaceType.Attraction:
                        @event.AttractionEventLinks.Add(new AttractionEventLink
                        {
                            EventId = @event.Id,
                            AttractionId = item.Id
                        });
                        break;

                    case PlaceType.Trip:
                        @event.TripEventLinks.Add(new TripEventLink
                        {
                            EventId = @event.Id,
                            TripId = item.Id
                        });
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });

            model.Participants?.Remove(model.CreateUserId);
            model.Participants?.ForEach(id =>
            {
                @event.Participants.Add(new Participant
                {
                    EventId = @event.Id,
                    UserId = id,
                    ParticipantRoleId = ParticipantRoleProfile.User
                });
            });
        }

        @event.Chats = new List<Chat>
        {
            new()
            {
                EventId = @event.Id,
                Name = "Main"
            }
        };

        await _context.SaveChangesAsync();

        if (model.Image != null)
        {
            await UpdateImageAsync(@event.Id, model.Image);
        }

        return await GetEvent(@event.Id);
    }

    public async Task DeleteEvent(int id)
    {
        var @event = await Events.FirstOrDefaultAsync(e => e.Id.Equals(id));

        if (@event == null)
        {
            return;
        }

        @event.Display = false;

        await _context.SaveChangesAsync();
    }

    public async Task<EventDetailsModel> UpdateEvent(UpdateEventModel model)
    {
        var @event = Events.Include(e => e.TripEventLinks)
            .FirstOrDefault(e => e.Id.Equals(model.Id));

        if (@event == null)
        {
            throw new Exception("Event not found");
        }

        _mapper.Map(model, @event);

        _context.Events.Update(@event);
        await _context.SaveChangesAsync();

        return await GetEvent(@event.Id);
    }
}
