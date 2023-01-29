using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldAround.Domain.Entities;

namespace WorldAround.Infrastructure.Configuration;

public class TripEventLinkConfiguration : IEntityTypeConfiguration<TripEventLink>
{
    public void Configure(EntityTypeBuilder<TripEventLink> entity)
    {
        entity.HasKey(e => new { e.TripId, e.EventId });

        entity.HasOne(e => e.Trip)
            .WithMany(e => e.TripEventLinks)
            .HasForeignKey(e => e.TripId)
            .OnDelete(DeleteBehavior.NoAction);

        entity.HasOne(e => e.Event)
            .WithMany(e => e.TripEventLinks)
            .HasForeignKey(e => e.EventId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
