using WorldAround.Domain.Enums;

namespace WorldAround.Domain.Entities;

public class Event
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string ImagePath { get; set; }
    public bool Display { get; set; }

    public AccessibilityProfile AccessibilityId { get; set; }

    public Accessibility Accessibility { get; set; }

    public List<Album> Albums { get; set; }
    public List<Image> Images { get; set; }
    public List<EquipmentGroup> EquipmentGroups { get; set; }
    public List<Equipment> Equipments { get; set; }
    public List<Chat> Chats { get; set; }
    public List<Message> Messages { get; set; }
    public List<Participant> Participants { get; set; }
    public List<TripEventLink> TripEventLinks { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Rating> Ratings { get; set; }
    public List<AttractionEventLink> AttractionEventLinks { get; set; }
}
