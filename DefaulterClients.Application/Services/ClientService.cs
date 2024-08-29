using AutoMapper;
using DefaulterClients.Application.DTOs.Request.Client;
using DefaulterClients.Application.DTOs.Result.Client;
using DefaulterClients.Application.Interfaces;
using DefaulterClients.Domain.Entities;
using DefaulterClients.Domain.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DefaulterClients.Application.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IUserRepository _userRepository;
    
    private readonly IMapper _mapper;

    public ClientService(IClientRepository clientRepository,IUserRepository userRepository, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<ClientResponse> CreateClient(ClientRequestDTO client)
    {
        var clientMapped =  _mapper.Map<Client>(client);

        var user = await _userRepository.GetUserByIdAsync(client.UserId)?? throw new Exception("User not found"); 

        var clientCreated = await _clientRepository.CreateAsync(clientMapped);

        return _mapper.Map<ClientResponse>(clientCreated);

    }

    public async Task<ClientResponse> DeleteClient(Guid id)
    {
        var client =  await _clientRepository.GetByIdAsync(id) ?? throw new Exception("User not found");

        var clientDeleted = await _clientRepository.DeleteAsync(client);

        return _mapper.Map<ClientResponse>(clientDeleted);
    }

    public async Task<ClientResponse> GetClientById(Guid id)
    {
        var client = await _clientRepository.GetByIdAsync(id);
        return _mapper.Map<ClientResponse>(client);

    }

    public async Task<List<ClientResponse>> GetClients()
    {
        var clients =  await _clientRepository.GetClientsAsync();

        return _mapper.Map<List<ClientResponse>>(clients);
    }

    public async Task<List<ClientResponse>> GetClientsByUserId(Guid id)
    {
       var clients = await _clientRepository.GetAllClientsByUserIdAsync(id);

        var clientsResponse = _mapper.Map<List<ClientResponse>>(clients);

        var result = new List<ClientResponse>();

        return clientsResponse.Select(x => new ClientResponse
        {
            id = x.id,
            Name = x.Name,
            Document = x.Document,
            Phone = x.Phone,
            Adress = x.Adress,
            PaidQuantity = x.Billings.Count(c => c.Paid == true),
            OpenQuantity =  x.Billings.Count(c => c.Paid == false && c.DueDate > DateTime.Now
            ),
            LateQuantity = x.Billings.Count(c => c.Paid == false  && c.DueDate < DateTime.Now),
            UserId = x.UserId,
            User = x.User,
            Billings =x.Billings

        }).ToList();
    }

    public async Task<ClientResponse> UpdateClient(Guid id,ClientUpdateRequestDTO clientDto)
    {
        var client = await _clientRepository.GetByIdAsync(id);

        var clientMapped = _mapper.Map(clientDto, client);

        clientMapped!.UpdateDates();

       var clientUpdated = await _clientRepository.UpdateAsync(clientMapped);

        return _mapper.Map<ClientResponse>(clientUpdated);

    }
}
