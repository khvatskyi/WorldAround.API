using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldAround.Domain.Entities;

namespace WorldAround.Infrastructure.Configuration;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> entity)
    {
        entity.HasKey(x => x.Id);

        entity.HasOne(e => e.Event)
            .WithMany(e => e.Images)
            .HasForeignKey(e => e.EventId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        entity.HasOne(e => e.Trip)
            .WithMany(e => e.Images)
            .HasForeignKey(e => e.TripId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        entity.HasOne(e => e.Attraction)
            .WithMany(e => e.Images)
            .HasForeignKey(e => e.AttractionId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(e => e.Pin)
            .WithMany(e => e.Images)
            .HasForeignKey(e => e.PinId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(e => e.Album)
            .WithMany(e => e.Images)
            .HasForeignKey(e => e.AlbumId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
