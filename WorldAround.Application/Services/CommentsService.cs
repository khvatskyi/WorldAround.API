using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorldAround.Application.Interfaces.Application;
using WorldAround.Application.Interfaces.Infrastructure;
using WorldAround.Domain.Entities;
using WorldAround.Domain.Enums;
using WorldAround.Domain.Models.Comments;

namespace WorldAround.Application.Services;

public class CommentsService : ICommentsService
{
    private readonly IWorldAroundDbContext _context;
    private readonly IMapper _mapper;

    public CommentsService(
        IWorldAroundDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<CommentModel>> GetCommentsAsync(GetCommentsModel model, CancellationToken cancellationToken)
    {
        var commentsQuery = _context.Comments.Where(x => x.ParentCommentId == null);

        commentsQuery = model.TargetType switch
        {
            TargetType.Trip => commentsQuery.Where(x => x.TripId == model.TargetId),
            TargetType.Attraction => commentsQuery.Where(x => x.AttractionId == model.TargetId),
            TargetType.Event => commentsQuery.Where(x => x.EventId == model.TargetId),
            TargetType.User => commentsQuery.Where(x => x.UserId == model.TargetId),
            _ => throw new ArgumentOutOfRangeException(nameof(model.TargetType), "Invalid target type."),
        };

        var result = await commentsQuery
            .Include(x => x.ChildComments)
                .ThenInclude(x=>x.Author)
            .Include(x => x.Author)
            .ThenInclude(x => x.Image)
            .OrderByDescending(x => x.CreateDate)
            .ToArrayAsync(cancellationToken);

        return _mapper.Map<IReadOnlyCollection<CommentModel>>(result);
    }

    public async Task<CommentModel> AddCommentAsync(AddCommentModel model)
    {
        var comment = _mapper.Map<Comment>(model);

        switch (model.TargetType)
        {
            case TargetType.Trip:
                comment.TripId = model.TargetId;
                break;
            case TargetType.Attraction:
                comment.AttractionId = model.TargetId;
                break;
            case TargetType.Event:
                comment.EventId = model.TargetId;
                break;
            case TargetType.User:
                comment.UserId = model.TargetId;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(model.TargetType), "Invalid target type.");
        }

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

        var author = await _context.Users
            .Include(x => x.Image)
            .FirstOrDefaultAsync(x => x.Id == comment.AuthorId);
        comment.Author = author;

        return _mapper.Map<CommentModel>(comment);
    }

    public async Task UpdateCommentAsync(UpdateCommentModel model)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == model.Id);
        if (comment == null)
        {
            throw new ArgumentException("Invalid comment id.");

        }

        comment.Text = model.Text;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCommentAsync(int id)
    {
        var comments = _context.Comments.Where(x => x.Id == id || x.ParentCommentId == id);
        _context.Comments.RemoveRange(comments);
        await _context.SaveChangesAsync();
    }
}