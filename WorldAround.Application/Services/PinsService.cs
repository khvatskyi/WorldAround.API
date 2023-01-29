using Microsoft.EntityFrameworkCore;
using WorldAround.Application.Interfaces.Application;
using WorldAround.Application.Interfaces.Infrastructure;
using WorldAround.Domain.Models.Pins;

namespace WorldAround.Application.Services;

public class PinsService : IPinsService
{
    private readonly IWorldAroundDbContext _context;

    public PinsService(IWorldAroundDbContext context)
    {
        _context = context;
    }

    public async Task UpdatePinAsync(UpdatePinModel model)
    {
        var pin = await _context.Pins.FirstOrDefaultAsync(x => x.Id == model.Id);

        if (pin != null)
        {
            pin.Name = model.Name;
            pin.Description = model.Description;
            pin.Latitude = model.Latitude;
            pin.Longitude = model.Longitude;

            _context.Pins.Update(pin);
            await _context.SaveChangesAsync();
        }
    }
}