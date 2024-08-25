using DefaulterClients.Domain.Entities;

namespace DefaulterClients.Domain.Interfaces;

public interface IBillingRepository
{
    Task<IEnumerable<Billing>> GetBillingsAsync();

    Task<List<Billing>> GetAllBillingsByClientIdAsync(Guid id); 

    Task<Billing?> GetByIdAsync(Guid id);

    Task<Billing> CreateAsync(Billing billing);

    Task<Billing> UpdateAsync(Billing billing);

    Task<Billing> RemoveAsync(Billing billing);
}
