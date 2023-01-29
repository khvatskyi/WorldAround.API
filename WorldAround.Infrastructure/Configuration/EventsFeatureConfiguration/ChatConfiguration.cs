using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldAround.Domain.Entities;

namespace WorldAround.Infrastructure.Configuration;

public class ChatConfiguration : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Name)
            .HasMaxLength(70)
            .IsRequired();

        entity.HasOne(e => e.Event)
            .WithMany(e => e.Chats)
            .HasForeignKey(e => e.EventId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
