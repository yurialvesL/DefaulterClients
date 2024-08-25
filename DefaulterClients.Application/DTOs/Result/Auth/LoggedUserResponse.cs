using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace DefaulterClients.Application.DTOs.Result.Auth;

public class LoggedUserResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string AcessToken { get; set; }
}
