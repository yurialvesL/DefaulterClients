using DefaulterClients.Domain.Entities;
using DefaulterClients.Domain.Interfaces;
using DefaulterClients.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DefaulterClients.Infraestructure.Repositories;

public class UserRepository : IUserRepository
{

    private ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<User> CreateAsync(User user)
    {
       _context.Add(user);
       await _context.SaveChangesAsync();
       return user;
    }

    public async Task<User?> GetUserByIdAsync(Guid id) => await _context.Users.Include(c => c.Clients).AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();

    public async Task<List<User>> GetUsersAsync() =>  await _context.Users.AsNoTracking().ToListAsync();
    

    public async Task<User> UpdateAsync(User user)
    {
        _context.Update(user);
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> RemoveAsync(User user)
    {
        _context.Remove(user);
        await _context.SaveChangesAsync();
        return user;
        
    }

    public async Task<User?> CheckUserByEmailAsync(string email)=> await _context.Users.AsNoTracking().Where(
                                                                                                        e => e.Email == email)
                                                                                                        .FirstOrDefaultAsync();
    
}
