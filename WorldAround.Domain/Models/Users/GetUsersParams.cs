using WorldAround.Domain.Models.Base;

namespace WorldAround.Domain.Models.Users;

public class GetUsersParams : GetDataParams
{
    public string Name { get; set; }
}
