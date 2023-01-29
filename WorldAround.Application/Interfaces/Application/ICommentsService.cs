using WorldAround.Domain.Models.Comments;

namespace WorldAround.Application.Interfaces.Application;

public interface ICommentsService
{
    Task<IReadOnlyCollection<CommentModel>> GetCommentsAsync(GetCommentsModel model,
        CancellationToken cancellationToken);

    Task<CommentModel> AddCommentAsync(AddCommentModel model);

    Task UpdateCommentAsync(UpdateCommentModel model);

    Task DeleteCommentAsync(int id);
}