using DefaulterClients.Domain.Entities;


namespace DefaulterClients.Application.DTOs.Result.Client;

public class ClientResponse
{
    public Guid id {  get; set; }
    public string Name { get; set; }
    public string Document { get; set; }
    public string Phone { get; set; }
    public string Adress { get; set; }
    public int PaidQuantity { get; set; }
    public int OpenQuantity { get; set; }
    public int LateQuantity { get; set; }
    public Guid UserId { get; set; }
    public DefaulterClients.Domain.Entities.User? User { get; set; }
    public List<DefaulterClients.Domain.Entities.Billing> Billings { get; set; }
}
