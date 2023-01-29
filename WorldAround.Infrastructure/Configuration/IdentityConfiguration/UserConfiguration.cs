using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldAround.Domain.Entities;

namespace WorldAround.Infrastructure.Configuration.IdentityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.HasKey(x => x.Id);

        entity.Property(x => x.FirstName)
            .HasMaxLength(50);

        entity.Property(x => x.LastName)
            .HasMaxLength(50);

        entity.Property(x => x.EmailConfirmed)
            .HasDefaultValue(true);

        entity.Property(x => x.IsActive)
            .HasDefaultValue(true);

        entity.HasOne(e => e.Image)
            .WithMany(e => e.Users)
            .HasForeignKey(e => e.ImageId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
