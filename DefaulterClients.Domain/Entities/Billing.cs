namespace DefaulterClients.Domain.Entities;

public class Billing: Entity
{
    public string Description { get; set; }

    public decimal Value { get; set; }
    
    public DateTime DueDate { get; set; }

    public bool Paid { get; set; }

    public Guid ClientId { get; set; }
    public Client Client { get; set; }


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
