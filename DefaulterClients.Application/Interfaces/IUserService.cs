using DefaulterClients.Application.DTOs.Request.User;
using DefaulterClients.Application.DTOs.Result.User;
using DefaulterClients.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaulterClients.Application.Interfaces;

public interface IUserService
{
    Task<UserResponse> CreateUser(UserResquestDTO user);

    Task<UserResponse?> CheckUser(LoginModelRequestDTO user);

    Task<UserResponse> UpdateUser(UserByIdResponse user, UserUpdateRequestDTO userDTO);

    Task<bool> UpdatePassword(Guid id,string oldPassword, string password);

    Task<List<UserResponse>> GetUsers();

    Task<UserDeletedResponse> DeleteUserById(Guid id);

    Task<UserByIdResponse?> GetUserById(Guid id);

    bool VerifyPassword(string hashedPassword, string providedPassword);
}
