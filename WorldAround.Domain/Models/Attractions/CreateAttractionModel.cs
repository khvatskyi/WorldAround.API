using Microsoft.AspNetCore.Http;

namespace WorldAround.Domain.Models.Attractions;

public class CreateAttractionModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int AuthorId { get; set; }

    public IFormFile Image { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }
}