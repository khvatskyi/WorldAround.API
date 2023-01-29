using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldAround.Domain.Entities;

namespace WorldAround.Infrastructure.Configuration;

public class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> entity)
    {
        entity.HasKey(x => x.Id);

        entity.HasOne(x => x.Author)
            .WithMany(x => x.CreatedRatings)
            .HasForeignKey(x => x.AuthorId)
            .OnDelete(DeleteBehavior.NoAction);

        entity.HasOne(x => x.Trip)
            .WithMany(x => x.Ratings)
            .HasForeignKey(x => x.TripId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(x => x.Event)
            .WithMany(x => x.Ratings)
            .HasForeignKey(x => x.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(x => x.Attraction)
            .WithMany(x => x.Ratings)
            .HasForeignKey(x => x.AttractionId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(x => x.User)
            .WithMany(x => x.Ratings)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}