namespace WorldAround.Domain.Entities;

public class Equipment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double NeededQuantity { get; set; }
    public double ActualQuantity { get; set; }

    public int EventId { get; set; }
    public int? EquipmentGroupId { get; set; }

    public Event Event { get; set; }
    public EquipmentGroup EquipmentGroup { get; set; }
}
