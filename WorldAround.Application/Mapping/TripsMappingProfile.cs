using AutoMapper;
using WorldAround.Domain.Entities;
using WorldAround.Domain.Enums;
using WorldAround.Domain.Models.Events;
using WorldAround.Domain.Models.Trips;

namespace WorldAround.Application.Mapping;

public class TripsMappingProfile : Profile
{
    public TripsMappingProfile()
    {
        CreateMap<Trip, TripModel>()
            .ForMember(d => d.Pins, o => o.MapFrom(s => s.Pins))
            ;

        CreateMap<PinModel, Pin>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.SequenceNumber, o => o.MapFrom(s => s.SeqNo))
            ;

        CreateMap<Pin, PinModel>()
            .ForMember(d => d.SeqNo, o => o.MapFrom(s => s.SequenceNumber))
            ;

        CreateMap<Trip, PlaceItem>()
            .ForMember(dest => dest.PlaceType, opts => opts.MapFrom(src => PlaceType.Trip));
    }
}
