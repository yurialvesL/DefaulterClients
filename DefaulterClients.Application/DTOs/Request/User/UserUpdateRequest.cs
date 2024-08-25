using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DefaulterClients.Application.DTOs.Request.User;

public class UserUpdateRequestDTO
{
    public string Name { get; set; }
    public string Email { get; set; }

}
