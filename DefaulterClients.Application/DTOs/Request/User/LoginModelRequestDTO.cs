using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaulterClients.Application.DTOs.Request.User;

public class LoginModelRequestDTO
{

    [Required(ErrorMessage = "User Name is Required")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}
