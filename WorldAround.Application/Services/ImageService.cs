using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorldAround.Application.Interfaces.Application;
using WorldAround.Application.Interfaces.Infrastructure;
using WorldAround.Domain.Entities;
using WorldAround.Domain.Models.Images;

namespace WorldAround.Application.Services;

public class ImageService : IImageService
{
    private readonly IMapper _mapper;
    private readonly IWorldAroundDbContext _context;

    public ImageService(
        IMapper mapper
        , IWorldAroundDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ImageModel> Get(int id)
    {
        return _mapper.Map<ImageModel>(await _context.Images.FirstOrDefaultAsync(e => e.Id == id));
    }

    public async Task<ImageModel> Create(Image image)
    {
        await _context.Images.AddAsync(image);

        return _mapper.Map<ImageModel>(image);
    }

    public async Task Delete(int id)
    {
        var image = await _context.Images.AsNoTracking().FirstAsync(e => e.Id == id);

        _context.Images.Remove(image);
        await _context.SaveChangesAsync();
    }
}
