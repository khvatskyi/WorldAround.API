namespace WorldAround.Domain.Models.Comments;

public class CommentModel
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public string Text { get; set; }
    public List<CommentModel> ChildComments { get; set; }

    public int AuthorId { get; set; }
    public string AuthorName { get; set; }
    public string ImagePath { get; set; }
}