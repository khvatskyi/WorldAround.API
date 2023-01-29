using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldAround.Domain.Entities;

namespace WorldAround.Infrastructure.Configuration;

public class AccessibilityConfiguration : IEntityTypeConfiguration<Accessibility>
{
    public void Configure(EntityTypeBuilder<Accessibility> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Name)
            .HasMaxLength(50)
            .IsRequired();
    }
}
