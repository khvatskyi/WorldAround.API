using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldAround.Domain.Entities;

namespace WorldAround.Infrastructure.Configuration;

public class ParticipantPermissionLinkConfiguration : IEntityTypeConfiguration<ParticipantPermissionLink>
{
    public void Configure(EntityTypeBuilder<ParticipantPermissionLink> entity)
    {
        entity.HasKey(e => new { e.ParticipantId, e.PermissionId });

        entity.HasOne(e => e.Participant)
            .WithMany(e => e.ParticipantPermissionLinks)
            .HasForeignKey(e => e.ParticipantId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(e => e.Permission)
            .WithMany(e => e.ParticipantPermissionLinks)
            .HasForeignKey(e => e.PermissionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
