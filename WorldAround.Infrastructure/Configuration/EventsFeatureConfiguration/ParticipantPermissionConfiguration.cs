using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldAround.Domain.Entities;

namespace WorldAround.Infrastructure.Configuration;

public class ParticipantPermissionConfiguration : IEntityTypeConfiguration<ParticipantPermission>
{
    public void Configure(EntityTypeBuilder<ParticipantPermission> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Name)
            .HasMaxLength(30)
            .IsRequired();

        entity.Property(e => e.Description)
            .HasMaxLength(200)
            .IsRequired(false);
    }
}
