using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldAround.Domain.Entities;

namespace WorldAround.Infrastructure.Configuration;

public class PinConfiguration : IEntityTypeConfiguration<Pin>
{
    public void Configure(EntityTypeBuilder<Pin> entity)
    {
        entity.HasKey(x => x.Id);

        entity.Property(x => x.Name)
            .HasMaxLength(30);

        entity.Property(x => x.Description)
            .HasMaxLength(250);

        entity.HasOne(x => x.Trip)
            .WithMany(x => x.Pins)
            .HasForeignKey(x => x.TripId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(x => x.Attraction)
            .WithMany(x => x.Pins)
            .HasForeignKey(x => x.AttractionId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}