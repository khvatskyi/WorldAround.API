using WorldAround.Domain.Enums;

namespace WorldAround.Domain.Models.Comments;

public class GetCommentsModel
{
    public int TargetId { get; set; }
    public TargetType TargetType { get; set; }
}