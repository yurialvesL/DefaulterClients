using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaulterClients.Application.DTOs.Request.Billing;

public class BillingRequestDTO
{
    [Required(ErrorMessage = "The Description is obrigatory")]
    [MinLength(30)]
    public string Description { get; set; }

    [Required(ErrorMessage = "Please advise the price")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    public decimal Value { get; set; }

    [Required(ErrorMessage = "The Due Data is obrigatory")]
    public DateTime DueDate { get; set; }

    [Required(ErrorMessage = "The paid is obrigatory")]
    public bool Paid { get; set; }

    [Required(ErrorMessage = "The ClientId is obrigatory")]
    public Guid ClientId { get; set; }


}
