﻿using DefaulterClients.Application.DTOs.Result.User;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DefaulterClients.Application.Interfaces;

public interface ITokenService
{
    string GenerateAccessToken(UserResponse user, IConfiguration _config);
}
