using DefaulterClients.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaulterClients.Application.DTOs.Result.Billing;

public class BillingResult
{
    public Guid Id  { get; set; }

    public string Description { get; set; }

    public decimal Value { get; set; }

    public DateTime DueDate { get; set; }

    public bool Paid { get; set; }

    public Guid ClientId { get; set; }

    public DefaulterClients.Domain.Entities.Client Client { get; set; }
}
