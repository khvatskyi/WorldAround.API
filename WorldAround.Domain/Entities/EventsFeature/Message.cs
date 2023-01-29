namespace WorldAround.Domain.Entities;

public class Message
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsRead { get; set; }
    public bool Display { get; set; }

    public int EventId { get; set; }
    public int AuthorId { get; set; }
    public Guid? ReplyMessageId { get; set; }
    public int? ChatId { get; set; }

    public Event Event { get; set; }
    public Chat Chat { get; set; }
    public Message ReplyMessage { get; set; }

    public List<Message> ReplyMessages { get; set; }
}
