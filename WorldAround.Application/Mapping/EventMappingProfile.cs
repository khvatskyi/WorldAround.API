using AutoMapper;
using WorldAround.Domain.Entities;
using WorldAround.Domain.Models.Events;
using WorldAround.Domain.Models.Trips;
using WorldAround.Domain.Models.Users;

namespace WorldAround.Application.Mapping;

public class EventMappingProfile : Profile
{
    public EventMappingProfile()
    {
        CreateMap<CreateEventModel, Event>()
            .ForMember(dest => dest.Participants, opts => opts.Ignore())
            .ForMember(dest => dest.TripEventLinks, opts => opts.Ignore())
            .ForMember(dest => dest.ImagePath, opts => opts.Ignore())
            .ForMember(dest => dest.Accessibility, opts => opts.Ignore())
            .ForMember(dest => dest.AccessibilityId, opts =>
            {
                opts.MapFrom(src => src.Accessibility);
                opts.Condition(m => m.Accessibility != 0);
            });

        CreateMap<Event, CreateEventModel>()
            .ForMember(dest => dest.Accessibility, opts => opts.MapFrom(src => src.AccessibilityId));

        CreateMap<UpdateEventModel, Event>()
            .ForMember(dest => dest.TripEventLinks, opts => opts.ConvertUsing(new UpdateEventModelValueFormatter(), src => src))
            .ForMember(dest => dest.StartDate, opts => opts.Condition(src => src.StartDate != null))
            .ForMember(dest => dest.EndDate, opts => opts.Condition(src => src.EndDate != null))
            .ForMember(dest => dest.Title, opts => opts.Condition(src => src.Title != null))
            .ForMember(dest => dest.Description, opts => opts.Condition(src => src.Description != null))
            .ForMember(dest => dest.Accessibility, opts => opts.Ignore())
            .ForMember(dest => dest.AccessibilityId, opts =>
            {
                opts.Condition(m => m.Accessibility != null);
                opts.MapFrom(src => src.Accessibility);
            });

        CreateMap<Event, GetEventModel>()
            .ForMember(dest => dest.Author, opts => opts.Ignore());
        CreateMap<Event, EventDetailsModel>()
            .ForMember(dest => dest.Image, opts => opts.MapFrom(src => src.ImagePath))
            .ForMember(dest => dest.Places, opts => opts.ConvertUsing(new GetEventModelValueFormatter(), src => src))
            .ForMember(dest => dest.Participants, opts => opts.MapFrom(src => src.Participants));
    }

    public class GetEventModelValueFormatter : IValueConverter<Event, List<PlaceItem>>
    {
        private readonly IMapper _mapper;

        public GetEventModelValueFormatter()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TripsMappingProfile>();
                cfg.AddProfile<AttractionsMappingProfile>();
            }).CreateMapper();
        }

        public List<PlaceItem> Convert(Event source, ResolutionContext context)
        {
            var placeItems = new List<PlaceItem>();

            source.TripEventLinks.ForEach(link =>
            {
                placeItems.Add(_mapper.Map<PlaceItem>(link.Trip));
            });

            source.AttractionEventLinks.ForEach(link =>
            {
                placeItems.Add(_mapper.Map<PlaceItem>(link.Attraction));
            });

            return placeItems;
        }
    }

    public class UpdateEventModelValueFormatter : IValueConverter<UpdateEventModel, List<TripEventLink>>
    {
        public List<TripEventLink> Convert(UpdateEventModel source, ResolutionContext context)
        {
            var tripEventLinks = new List<TripEventLink>();

            source.TripIds.ForEach(tripId =>
            {
                tripEventLinks.Add(new TripEventLink { EventId = source.Id, TripId = tripId });
            });

            return tripEventLinks;
        }
    }
}
