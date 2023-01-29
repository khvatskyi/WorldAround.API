using System.Net;
using AutoMapper;
using WorldAround.Domain.Entities;
using WorldAround.Domain.Models.Comments;

namespace WorldAround.Application.Mapping;

public class CommentsMappingProfile : Profile
{
    public CommentsMappingProfile()
    {
        CreateMap<Comment, CommentModel>()
            .ForMember(d => d.AuthorName, o => o.MapFrom(s => GetAuthorName(s.Author)))
            .ForMember(d => d.ImagePath, o => o.MapFrom(s => s.Author.Image.ImagePath))
            ;

        CreateMap<AddCommentModel, Comment>()
            .ForMember(d => d.CreateDate, o => o.MapFrom(s => DateTime.Now));
    }

    private static string GetAuthorName(User author)
    {
        if (author.FirstName != null || author.LastName != null)
        {
            return $"{author.FirstName} {author.LastName}".Trim();
        }

        return author.UserName;
    }
}