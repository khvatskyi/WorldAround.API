namespace WorldAround.Domain.Entities;

public class Chat
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int EventId { get; set; }

    public Event Event { get; set; }
    public List<Message> Messages { get; set; }
}
