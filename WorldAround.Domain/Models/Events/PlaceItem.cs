using WorldAround.Domain.Enums;

namespace WorldAround.Domain.Models.Events;

public class PlaceItem
{
    public int Id { get; set; }

    public string Name { get; set; }

    public PlaceType PlaceType { get; set; }
}
