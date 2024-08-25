using DefaulterClients.Domain.Entities;

namespace DefaulterClients.Domain.Interfaces;


public interface IUserRepository
{
    Task<List<User>> GetUsersAsync();

    Task<User?> GetUserByIdAsync(Guid id);

    Task<User?> CheckUserByEmailAsync(string email);

    Task<User> CreateAsync(User user);

    Task<User> UpdateAsync(User user);

    Task<User> RemoveAsync(User user);
}
