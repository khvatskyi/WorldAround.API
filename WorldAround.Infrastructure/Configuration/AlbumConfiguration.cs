using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldAround.Domain.Entities;

namespace WorldAround.Infrastructure.Configuration;

public class AlbumConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Name)
            .HasMaxLength(50);
        entity.Property(e => e.EventId)
            .IsRequired();

        entity.HasOne(e => e.Trip)
            .WithMany(e => e.Albums)
            .HasForeignKey(e => e.TripId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        entity.HasOne(e => e.Event)
            .WithMany(e => e.Albums)
            .HasForeignKey(e => e.EventId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
