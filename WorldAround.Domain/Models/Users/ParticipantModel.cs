using WorldAround.Domain.Enums;

namespace WorldAround.Domain.Models.Users;

public class ParticipantModel
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public ParticipantRoleProfile? ParticipantRoleId { get; set; }
}
