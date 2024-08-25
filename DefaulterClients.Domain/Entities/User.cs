namespace DefaulterClients.Domain.Entities;

public class User : Entity
{
    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }


    public ICollection<Client> Clients { get; set; }


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
