using AutoMapper;
using WorldAround.Domain.Entities;
using WorldAround.Domain.Models.Users;

namespace WorldAround.Application.Mapping;

public class ParticipantMappingProfile : Profile
{
    public ParticipantMappingProfile()
    {
        CreateMap<Participant, ParticipantModel>()
            .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.User.UserName))
            .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.User.LastName));
    }
}
