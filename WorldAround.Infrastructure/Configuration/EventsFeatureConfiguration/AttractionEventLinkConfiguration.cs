using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldAround.Domain.Entities;

namespace WorldAround.Infrastructure.Configuration;

public class AttractionEventLinkConfiguration : IEntityTypeConfiguration<AttractionEventLink>
{
    public void Configure(EntityTypeBuilder<AttractionEventLink> entity)
    {
        entity.HasKey(e => new { e.AttractionId, e.EventId });

        entity.HasOne(e => e.Attraction)
            .WithMany(e => e.AttractionEventLinks)
            .HasForeignKey(e => e.AttractionId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(e => e.Event)
            .WithMany(e => e.AttractionEventLinks)
            .HasForeignKey(e => e.EventId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
