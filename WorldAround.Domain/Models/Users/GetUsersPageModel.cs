using WorldAround.Domain.Models.Paging;

namespace WorldAround.Domain.Models.Users;

public class GetUsersPageModel
{
    public IEnumerable<UserModel> Users { get; set; }

    public PagingModel PageInfo { get; set; }
}
