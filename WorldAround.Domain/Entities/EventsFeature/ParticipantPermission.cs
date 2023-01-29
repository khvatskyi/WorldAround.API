namespace WorldAround.Domain.Entities;

public class ParticipantPermission
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public List<ParticipantPermissionLink> ParticipantPermissionLinks { get; set; }
}
