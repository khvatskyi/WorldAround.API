using WorldAround.Domain.Models.Pins;

namespace WorldAround.Application.Interfaces.Application;

public interface IPinsService
{
    Task UpdatePinAsync(UpdatePinModel model);
}