using DefaulterClients.Application.DTOs.Request.Billing;
using DefaulterClients.Application.DTOs.Result.Billing;
using DefaulterClients.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DefaulterClients.Controllers;


[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
[Authorize]
public class BillingController : ControllerBase
{
    private readonly IBillingService _billingService;
    private readonly IClientService _clientService;

    public BillingController(IBillingService billingService, IClientService clientService)
    {
        _billingService = billingService;
        _clientService = clientService;
    }

    [HttpGet("ByClientId/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<BillingResult>>> GetBillingsByClientId(Guid id)
    {
        var client = await  _clientService.GetClientById(id);

        if(client is null)
            return NotFound("Client not found");

        var billings = await _billingService.GetBillingByClientId(id);

        if (billings is null)
            return NotFound("This client don't have billing");

        return Ok(billings);

    }

    [HttpGet("ById/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BillingResult>> GetBillings(Guid id)
    {
        var billing = await _billingService.GetById(id);

        if (billing is null)
            return NotFound("Billing not found");

        return Ok(billing);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BillingResult>> CreateBilling(BillingRequestDTO billingDTO)
    {
        var billing = await _billingService.CreateBilling(billingDTO);

        if (billing is null)
            return BadRequest("An error occured");

        return Ok(billing);
    }

    [HttpPut("UpdateBilling/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BillingResult>> UpdateBilling(BillingRequestDTO billingDto, Guid id)
    {
        var billingGet =await _billingService.GetById(id);

        if (billingGet is null)
            return NotFound("Billing not found");

        var billing = await _billingService.UpdateBilling(id,billingDto);

        return Ok(billing);

        
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BillingResult>> DeleteById(Guid id)
    {
        var billing = await _billingService.DeleteBillingById(id);

        return Ok(billing);
    }
}
