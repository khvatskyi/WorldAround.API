using WorldAround.Domain.Enums;

namespace WorldAround.Domain.Entities;

public class ParticipantRole
{
    public ParticipantRoleProfile Id { get; set; }
    public string Name { get; set; }

    public List<Participant> Participants { get; set; }
}
