using DefaulterClients.Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaulterClients.Application.DTOs.Result.User;

public class UserByIdResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string  Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public List<DefaulterClients.Domain.Entities.Client> Clients { get; set; }
  
}
