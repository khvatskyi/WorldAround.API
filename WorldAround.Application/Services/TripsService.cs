using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorldAround.Application.Interfaces.Application;
using WorldAround.Application.Interfaces.Infrastructure;
using WorldAround.Domain.Entities;
using WorldAround.Domain.Models.Trips;

namespace WorldAround.Application.Services;

public class TripsService : ITripsService
{
    private readonly IWorldAroundDbContext _context;
    private readonly IMapper _mapper;

    public TripsService(
        IWorldAroundDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TripModel> GetTripAsync(int tripId, CancellationToken cancellationToken)
    {
        var trip = await _context.Trips
            .Include(x => x.Pins)
            .FirstOrDefaultAsync(x => x.Id == tripId, cancellationToken);

        return _mapper.Map<TripModel>(trip);
    }

    public async Task<GetTripsModel> GetTripsAsync(GetTripsParams @params,
        CancellationToken cancellationToken)
    {
        var tripsQuery = _context.Trips.AsQueryable();

        if (@params.IncludePins)
        {
            tripsQuery = tripsQuery.Include(x => x.Pins);
        }

        if (@params.UserId is not null)
        {
            tripsQuery = tripsQuery.Where(x => x.AuthorId == @params.UserId);
        }

        if (!string.IsNullOrWhiteSpace(@params.SearchValue))
        {
            var searchValue = @params.SearchValue.ToLower();
            tripsQuery = tripsQuery.Where(x =>
                x.Name.ToLower().Contains(searchValue) || x.Description.ToLower().Contains(searchValue));
        }

        var result = await _context.Trips.Select(x => new
        {
            Data = tripsQuery
                .Skip(@params.PageIndex * @params.PageSize)
                .Take(@params.PageSize)
                .ToList(),
            Length = tripsQuery.Count()
        }).FirstOrDefaultAsync(cancellationToken);

        return new GetTripsModel
        {
            Data = _mapper.Map<IReadOnlyCollection<TripModel>>(result?.Data),
            Length = result?.Length ?? 0
        };
    }

    public async Task CreateTripAsync(CreateTripModel model)
    {
        var trip = new Trip
        {
            Name = model.Name,
            Description = model.Description,
            AuthorId = model.AuthorId,
            CreateDate = DateTime.Now,
            Pins = model.Pins.Select(x => new Pin
            {
                Name = x.Name,
                Description = x.Description,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                SequenceNumber = x.SeqNo
            }).ToList()
        };

        _context.Trips.Add(trip);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTripNameAsync(UpdateTripModel model)
    {
        var trip = await _context.Trips.FirstOrDefaultAsync(x => x.Id == model.TripId);

        if (trip != null)
        {
            trip.Name = model.Value;
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateTripDescriptionAsync(UpdateTripModel model)
    {
        var trip = await _context.Trips.FirstOrDefaultAsync(x => x.Id == model.TripId);

        if (trip != null)
        {
            trip.Description = model.Value;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteTripAsync(int tripId)
    {
        var trip = await _context.Trips.FirstOrDefaultAsync(x => x.Id == tripId);

        if (trip != null)
        {
            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
        }
    }
}