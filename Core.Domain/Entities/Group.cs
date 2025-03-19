namespace Core.Domain.Entities;

public class Group
{
    public string Id { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
