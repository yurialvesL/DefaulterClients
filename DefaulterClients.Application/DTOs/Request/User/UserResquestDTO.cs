using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaulterClients.Application.DTOs.Request.User;

public class UserResquestDTO
{
    [Required(ErrorMessage = "The Name is obrigatory")]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required(ErrorMessage = "The Email is obrigatory")]
    [MaxLength(254)]
    public string Email { get; set; }

    [Required(ErrorMessage = "The Password is obrigatory")]
    [MinLength(8)]
    public string Password { get; set; }
}
