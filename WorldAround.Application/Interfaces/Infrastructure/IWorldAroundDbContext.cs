using Microsoft.EntityFrameworkCore;
using WorldAround.Domain.Entities;

namespace WorldAround.Application.Interfaces.Infrastructure;

public interface IWorldAroundDbContext
{
    public DbSet<Attraction> Attractions { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Pin> Pins { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Accessibility> Accessibilities { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<EquipmentGroup> EquipmentsGroups { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Participant> Participants { get; set; }
    public DbSet<ParticipantPermission> ParticipantsPermissions { get; set; }
    public DbSet<ParticipantPermissionLink> ParticipantPermissionLinks { get; set; }
    public DbSet<ParticipantRole> ParticipantRoles { get; set; }
    public DbSet<TripEventLink> TripEventLinks { get; set; }
    public DbSet<User> Users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
