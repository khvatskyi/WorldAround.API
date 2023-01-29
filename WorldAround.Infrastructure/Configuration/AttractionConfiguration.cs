using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldAround.Domain.Entities;

namespace WorldAround.Infrastructure.Configuration;

public class AttractionConfiguration : IEntityTypeConfiguration<Attraction>
{
    public void Configure(EntityTypeBuilder<Attraction> entity)
    {
        entity.HasKey(x => x.Id);

        entity.Property(x => x.Name)
            .HasMaxLength(50);

        entity.Property(x => x.Description)
            .HasMaxLength(2000);

        entity.HasOne(x => x.Author)
            .WithMany(x => x.CreatedAttractions)
            .HasForeignKey(x => x.AuthorId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}