using AutoMapper;
using WorldAround.Domain.Entities;
using WorldAround.Domain.Models.Images;

namespace WorldAround.Application.Mapping;

public class ImageMappingProfile : Profile
{
    public ImageMappingProfile()
    {
        CreateMap<Image, ImageModel>()
            .ReverseMap();
    }
}
