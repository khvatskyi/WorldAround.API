using Microsoft.AspNetCore.Mvc;
using WorldAround.Application.Interfaces.Application;
using WorldAround.Domain.Models.Comments;

namespace WorldAround.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly ICommentsService _commentsService;

    public CommentsController(ICommentsService commentsService)
    {
        _commentsService = commentsService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<CommentModel>>> GetComments(
        [FromQuery] GetCommentsModel getCommentsModel, CancellationToken cancellationToken)
    {
        var comments = await _commentsService.GetCommentsAsync(getCommentsModel, cancellationToken);

        return Ok(comments);
    }

    [HttpPost]
    public async Task<ActionResult<CommentModel>> AddComment(AddCommentModel model)
    {
        var comment = await _commentsService.AddCommentAsync(model);

        return Ok(comment);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateComment(UpdateCommentModel model)
    {
        await _commentsService.UpdateCommentAsync(model);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteComment(int id)
    {
        await _commentsService.DeleteCommentAsync(id);

        return NoContent();
    }
}