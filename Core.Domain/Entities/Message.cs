namespace Core.Domain.Entities;

public class Message
{
    public string Messagetext { get; set; } = null!;

    public string Id { get; set; } = null!;

    public string Userid { get; set; } = null!;

    public string Groupid { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
