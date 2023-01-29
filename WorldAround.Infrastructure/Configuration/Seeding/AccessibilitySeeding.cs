using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldAround.Domain.Entities;
using WorldAround.Domain.Enums;

namespace WorldAround.Infrastructure.Configuration.Seeding;

public class AccessibilitySeeding : IEntityTypeConfiguration<Accessibility>
{
    public void Configure(EntityTypeBuilder<Accessibility> entity)
    {
        entity.HasData(
            new Accessibility { Id = AccessibilityProfile.Public, Name = nameof(AccessibilityProfile.Public) },
            new Accessibility { Id = AccessibilityProfile.Private, Name = nameof(AccessibilityProfile.Private) });
    }
}
