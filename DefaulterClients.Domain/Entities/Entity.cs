namespace DefaulterClients.Domain.Entities;

public abstract class Entity
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; protected set; }

    public DateTime UpdatedAt { get; protected set; }

    protected Entity()
    {
        Id= Guid.NewGuid();
        CreatedAt= DateTime.UtcNow;
    }
}
