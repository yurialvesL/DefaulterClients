using DefaulterClients.Application.DTOs.Request.Client;
using DefaulterClients.Application.DTOs.Result.Client;
using DefaulterClients.Domain.Entities;

namespace DefaulterClients.Application.Interfaces;

public interface IClientService
{
    Task<List<ClientResponse>> GetClients();

    Task<List<ClientResponse>> GetClientsByUserId(Guid id);

    Task<ClientResponse> GetClientById(Guid id);

    Task<ClientResponse> CreateClient(ClientRequestDTO client);

    Task<ClientResponse> UpdateClient(Guid id,ClientUpdateRequestDTO clientDto);
    Task<ClientResponse> DeleteClient(Guid id);
}
