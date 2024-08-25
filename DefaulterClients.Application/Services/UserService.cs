using AutoMapper;
using DefaulterClients.Application.DTOs.Request.User;
using DefaulterClients.Application.DTOs.Result.User;
using DefaulterClients.Application.Interfaces;
using DefaulterClients.Domain.Entities;
using DefaulterClients.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace DefaulterClients.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<UserResponse?> CheckUser(LoginModelRequestDTO user)
    {
        var userResult = await _userRepository.CheckUserByEmailAsync(user.Email!);

        if (userResult is not null)
            return _mapper.Map<UserResponse>(userResult);

        return null;
    }

    public async Task<UserResponse> CreateUser(UserResquestDTO user)
    {
        var userCreate = _mapper.Map<User>(user);

        userCreate.Password = Hashpassword(userCreate.Password);

        var userResult = await _userRepository.CreateAsync(userCreate);

        return _mapper.Map<UserResponse>(userResult);

    }

    public async Task<UserDeletedResponse> DeleteUserById(Guid id)
    {
        var userReturn = await _userRepository.GetUserByIdAsync(id) ?? throw new Exception("User does not exists"); 

        var userRemoved = await _userRepository.RemoveAsync(userReturn);

        return _mapper.Map<UserDeletedResponse>(userRemoved);

    }

    public  async Task<UserByIdResponse?> GetUserById(Guid id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);

        if (user is not null)
            return _mapper.Map<UserByIdResponse>(user);

        return null;
    }

    public async Task<List<UserResponse>> GetUsers()
    {
        var users = await _userRepository.GetUsersAsync() ?? throw new Exception("There aren't users");
        return _mapper.Map<List<UserResponse>>(users)!;

    }
    public async Task<UserResponse> UpdateUser(UserByIdResponse user, UserUpdateRequestDTO userDTO)
    {
        var userWithData = _mapper.Map(userDTO,user);

        var userMapped = _mapper.Map<User>(userWithData);

        userMapped.UpdateDates();

        var userUpdated = await _userRepository.UpdateAsync(userMapped);

        return _mapper.Map<UserResponse>(userUpdated);

    }

    public async Task<bool> UpdatePassword(Guid id,string oldPassword, string password)
    {
        var user = await _userRepository.GetUserByIdAsync(id)!;

        if (VerifyPassword(user.Password, oldPassword))
        {
            user.Password = Hashpassword(password);

           var userUpdated =await _userRepository.UpdateAsync(user);

            if(userUpdated is not null)
                return true;
        }

        return false;
    }

    public bool VerifyPassword(string hashedPassword, string providedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);  
    }

    #region private methods
    private static string  Hashpassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

 
    #endregion
}
