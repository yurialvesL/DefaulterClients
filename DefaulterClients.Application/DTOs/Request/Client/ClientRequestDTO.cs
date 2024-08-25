using System.ComponentModel.DataAnnotations;

namespace DefaulterClients.Application.DTOs.Request.Client;


public class ClientRequestDTO
{
    [Required(ErrorMessage = "The Name is Obrigatory")]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required(ErrorMessage = "The Document is Obrigatory")]
    [MaxLength(350)]
    public string Document { get; set; }

    [Required(ErrorMessage = "The Phone is Obrigatory")]
    [MaxLength(15)]
    public string Phone { get; set; }

    [Required(ErrorMessage = "The Adress is Required")]
    [MaxLength(280)]
    public string Address { get; set; }

    [Required(ErrorMessage = "The User id is Obrigatory")]
    public Guid UserId { get; set; }

}
