using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldAround.Domain.Entities;
using WorldAround.Domain.Enums;

namespace WorldAround.Infrastructure.Configuration.Seeding;

public class ParticipantRoleSeeding : IEntityTypeConfiguration<ParticipantRole>
{
    public void Configure(EntityTypeBuilder<ParticipantRole> entity)
    {
        entity.HasData(
            new ParticipantRole { Id = ParticipantRoleProfile.Owner, Name = nameof(ParticipantRoleProfile.Owner) },
            new ParticipantRole { Id = ParticipantRoleProfile.Admin, Name = nameof(ParticipantRoleProfile.Admin) },
            new ParticipantRole { Id = ParticipantRoleProfile.User, Name = nameof(ParticipantRoleProfile.User) });
    }
}
