namespace WorldAround.Domain.Models.Users;

public class UpdateUserPasswordParameters
{
    public int UserId { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}
