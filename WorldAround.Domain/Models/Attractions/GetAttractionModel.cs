namespace WorldAround.Domain.Models.Attractions;

public class GetAttractionModel
{
    public int Id { get; set; }
    public int? AuthorId { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public string ImagePath { get; set; }
}