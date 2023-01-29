using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldAround.Domain.Entities;

namespace WorldAround.Infrastructure.Configuration;

public class ParticipantRoleConfiguration : IEntityTypeConfiguration<ParticipantRole>
{
    public void Configure(EntityTypeBuilder<ParticipantRole> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id)
            .ValueGeneratedNever();

        entity.Property(e => e.Name)
            .HasMaxLength(30)
            .IsRequired();
    }
}
