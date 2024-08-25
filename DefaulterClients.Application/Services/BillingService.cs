using AutoMapper;
using DefaulterClients.Application.DTOs.Request.Billing;
using DefaulterClients.Application.DTOs.Result.Billing;
using DefaulterClients.Application.Interfaces;
using DefaulterClients.Domain.Entities;
using DefaulterClients.Domain.Interfaces;

namespace DefaulterClients.Application.Services;

public class BillingService : IBillingService
{
    private readonly IBillingRepository _billingRepository;
    private readonly IMapper _mapper;

    public BillingService(IBillingRepository billingRepository, IMapper mapper)
    {
        _billingRepository = billingRepository;
        _mapper = mapper;
    }
    public async Task<BillingResult> CreateBilling(BillingRequestDTO billing)
    {
        var billingMapped = _mapper.Map<Billing>(billing);

        billingMapped.UpdateDates();

        var billingCreated =  await _billingRepository.CreateAsync(billingMapped);

       return _mapper.Map<BillingResult>(billingCreated);

    }

    public async Task<BillingResult> DeleteBillingById(Guid id)
    {
        var billing = await _billingRepository.GetByIdAsync(id);

        var billingDeleted = await _billingRepository.RemoveAsync(billing!);

        return _mapper.Map<BillingResult>(billingDeleted);
    }

    public async Task<List<BillingResult>> GetBillingByClientId(Guid id)
    {
        var billings = await _billingRepository.GetAllBillingsByClientIdAsync(id) ?? throw new Exception("Don't exists billings fot this client");

        return _mapper.Map<List<BillingResult>>(billings);

    }

    public async Task<BillingResult> GetById(Guid id)
    {

        var billing = await _billingRepository.GetByIdAsync(id);

        return _mapper.Map<BillingResult>(billing);

    }

    public async Task<BillingResult> UpdateBilling(Guid id,BillingRequestDTO billingDTO)
    {
        var billing = await _billingRepository.GetByIdAsync(id);

        var billingMapped = _mapper.Map(billingDTO, billing);

        var billingToUpdate = _mapper.Map<Billing>(billingMapped);

        billingToUpdate.UpdateDates();
        
        var billingResult = await _billingRepository.UpdateAsync(billingToUpdate);

        return _mapper.Map<BillingResult>(billingResult);
    }
}
