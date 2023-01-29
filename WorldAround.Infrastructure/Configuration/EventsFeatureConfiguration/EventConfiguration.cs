using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldAround.Domain.Entities;

namespace WorldAround.Infrastructure.Configuration;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Title)
            .HasMaxLength(30)
            .IsRequired();

        entity.Property(e => e.ImagePath)
            .IsRequired(false);

        entity.Property(e => e.EndDate)
            .IsRequired(false);

        entity.Property(e => e.CreateDate)
            .HasDefaultValueSql("GETDATE()");

        entity.Property(e => e.Display)
            .HasDefaultValue(true);

        entity.HasOne(e => e.Accessibility)
            .WithMany(e => e.Events)
            .HasForeignKey(e => e.AccessibilityId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
