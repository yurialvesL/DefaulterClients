using DefaulterClients.Domain.Entities;

namespace DefaulterClients.Domain.Interfaces;

public interface IClientRepository
{
    Task<List<Client>> GetClientsAsync();

    Task<List<Client>> GetAllClientsByUserIdAsync(Guid id);

    Task<Client?> GetByIdAsync(Guid id);

    Task<Client> CreateAsync(Client client);

    Task<Client> UpdateAsync(Client client);

    Task<Client> DeleteAsync(Client client);
}
