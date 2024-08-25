using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaulterClients.Application.DTOs.Request.User;

public class UpdatePasswordRequest
{
    public string oldPassword { get; set; }
    public string NewPassword { get; set; }
}
