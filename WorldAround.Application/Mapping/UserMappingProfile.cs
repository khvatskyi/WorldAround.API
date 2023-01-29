using AutoMapper;
using WorldAround.Domain.Entities;
using WorldAround.Domain.Models.Identity;
using WorldAround.Domain.Models.Users;

namespace WorldAround.Application.Mapping;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<RegistrationModel, User>();
        CreateMap<LoginModel, User>();
        CreateMap<UserModel, User>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<User, UserModel>()
            .ForMember(dest => dest.ImagePath,
                opts => opts.MapFrom(src => src.Image != null ? src.Image.ImagePath : null));
    }
}
