namespace DefaulterClients.Domain.Entities;

public class Client : Entity
{
    public string Name { get; set; }

    public string Document { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public ICollection<Billing> Billings { get; set; }


    public void UpdateDates()
    {
        if (CreatedAt == new DateTime())
        {
            CreatedAt = DateTime.UtcNow;
            return;
        }

        UpdatedAt = DateTime.UtcNow;
    }
}