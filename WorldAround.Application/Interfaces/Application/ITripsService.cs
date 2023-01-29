using WorldAround.Domain.Models.Comments;
using WorldAround.Domain.Models.Trips;

namespace WorldAround.Application.Interfaces.Application;

public interface ITripsService
{
    Task<TripModel> GetTripAsync(int tripId, CancellationToken cancellationToken);

    Task<GetTripsModel> GetTripsAsync(GetTripsParams @params, CancellationToken cancellationToken);

    Task CreateTripAsync(CreateTripModel model);

    Task UpdateTripNameAsync(UpdateTripModel model);

    Task UpdateTripDescriptionAsync(UpdateTripModel model);

    Task DeleteTripAsync(int tripId);
}