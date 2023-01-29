using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldAround.Domain.Entities;

namespace WorldAround.Infrastructure.Configuration;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Text)
            .HasMaxLength(2000)
            .IsRequired();

        entity.Property(e => e.IsRead)
            .HasDefaultValue(false);

        entity.Property(e => e.Display)
            .HasDefaultValue(true);

        entity.HasOne(e => e.Event)
            .WithMany(e => e.Messages)
            .HasForeignKey(e => e.EventId)
            .OnDelete(DeleteBehavior.NoAction);

        entity.HasOne(e => e.Chat)
            .WithMany(e => e.Messages)
            .HasForeignKey(e => e.ChatId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(e => e.ReplyMessage)
            .WithMany(e => e.ReplyMessages)
            .HasForeignKey(e => e.ReplyMessageId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
