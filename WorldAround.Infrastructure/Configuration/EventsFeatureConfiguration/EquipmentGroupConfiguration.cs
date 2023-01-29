using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldAround.Domain.Entities;

namespace WorldAround.Infrastructure.Configuration;

public class EquipmentGroupConfiguration : IEntityTypeConfiguration<EquipmentGroup>
{
    public void Configure(EntityTypeBuilder<EquipmentGroup> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Name)
            .HasMaxLength(30)
            .IsRequired();

        entity.HasOne(e => e.Event)
            .WithMany(e => e.EquipmentGroups)
            .HasForeignKey(e => e.EventId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
