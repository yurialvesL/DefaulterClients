using DefaulterClients.Domain.Entities;
using DefaulterClients.Domain.Interfaces;
using DefaulterClients.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DefaulterClients.Infraestructure.Repositories;

public class BillingRepository : IBillingRepository
{
    private ApplicationDbContext _context;

    public BillingRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Billing> CreateAsync(Billing billing)
    {
        _context.Billings.Add(billing);
        await _context.SaveChangesAsync();
        return billing;
    }

    public async Task<List<Billing>> GetAllBillingsByClientIdAsync(Guid id) => 
                                                    await _context.Billings.Include(b => b.Client).AsNoTracking().Where(c => c.ClientId == id).ToListAsync();
    

    public async Task<IEnumerable<Billing>> GetBillingsAsync() => await _context.Billings.ToListAsync();

    public async Task<Billing?> GetByIdAsync(Guid id) => await _context.Billings.Include(c=> c.Client).AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
   

    public async Task<Billing> RemoveAsync(Billing billing)
    {
        _context.Remove(billing);
        await _context.SaveChangesAsync();
        return billing;
    }

    public async Task<Billing> UpdateAsync(Billing billing)
    {
        _context.Update(billing);
        _context.Entry(billing).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return billing;
    }
}
