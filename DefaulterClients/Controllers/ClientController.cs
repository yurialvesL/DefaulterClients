using AutoMapper;
using DefaulterClients.Application.DTOs.Request.Client;
using DefaulterClients.Application.DTOs.Result.Client;
using DefaulterClients.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DefaulterClients.Controllers;


[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
[Authorize]
public class ClientController: ControllerBase
{
    private readonly IClientService _clientService;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public ClientController(IClientService clientService, IUserService userService, IMapper mapper)
    {
        _clientService = clientService;
        _userService = userService;
    }


    [HttpGet("Clients")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ClientResponse>>> GetClients()
    {
        var clients = await _clientService.GetClients();

        if (clients is null)
            return NotFound("Clients not found");

        return Ok(clients);
    }

    [HttpGet("UserId/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ClientResponse>>> GetClientsByUserId(Guid id)
    {
        var user = await _userService.GetUserById(id);

        if (user is null)
            return NotFound("Clients not found");

        var clients = await _clientService.GetClientsByUserId(id);

        if (clients is null)
            return NotFound("This client don't have any client");

        return Ok(clients);

    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<ClientResponse>> CreateClient(ClientRequestDTO clientRequestDTO)
    {
        var client = await _clientService.CreateClient(clientRequestDTO);

        if (client is null)
            return BadRequest("An Error occured while creating client");

        return Ok(client);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<ClientResponse>> UpdateClient(Guid id,ClientUpdateRequestDTO clientUpdateRequestDTO)
    {
        var client = await _clientService.GetClientById(id);

        if (client is null)
            return NotFound("client not found");


        var clientUpdated = await _clientService.UpdateClient(id, clientUpdateRequestDTO);

        return Ok(clientUpdated);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<ClientResponse>> DeleteClient(Guid id)
    {
        var client = await _clientService.GetClientById(id);

        if (client is null)
            return NotFound("Client not found");

        var clientDeleted = await _clientService.DeleteClient(id);

        return Ok(clientDeleted);
    }




}
