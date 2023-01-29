using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldAround.Domain.Entities;

namespace WorldAround.Infrastructure.Configuration;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> entity)
    {
        entity.HasKey(x => x.Id);

        entity.Property(x => x.Text)
            .HasMaxLength(500);

        entity.HasOne(x => x.Author)
            .WithMany(x => x.CreatedComments)
            .HasForeignKey(x => x.AuthorId)
            .OnDelete(DeleteBehavior.NoAction);

        entity.HasOne(x => x.Trip)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.TripId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(x => x.Event)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(x => x.Attraction)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.AttractionId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(x => x.User)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(x => x.ParentComment)
            .WithMany(x => x.ChildComments)
            .HasForeignKey(x => x.ParentCommentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}