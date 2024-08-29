using DefaulterClients.Domain.Entities;
using DefaulterClients.Domain.Interfaces;
using DefaulterClients.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DefaulterClients.Infraestructure.Repositories;

public class ClientRepository : IClientRepository
{

    private ApplicationDbContext _context;

    public ClientRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Client> CreateAsync(Client client)
    {
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<Client> DeleteAsync(Client client)
    {
        _context.Remove(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<Client?> GetByIdAsync(Guid id) => await _context.Clients.Include(b => b.Billings).FirstOrDefaultAsync(c => c.Id == id);

    public async Task<List<Client>> GetClientsAsync() => await _context.Clients.Include(b => b.Billings).ToListAsync();

    public async Task<List<Client>> GetAllClientsByUserIdAsync(Guid id) => await _context.Clients.Include(u => u.User).Include(b => b.Billings).AsNoTracking().
                                                                                                                    Where(c => c.UserId == id).ToListAsync();            
    
    public async Task<Client> UpdateAsync(Client client)
    {
        _context.Update(client);
        await _context.SaveChangesAsync();
        return client;
    }
}
