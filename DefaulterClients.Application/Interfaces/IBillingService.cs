using DefaulterClients.Application.DTOs.Request.Billing;
using DefaulterClients.Application.DTOs.Result.Billing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaulterClients.Application.Interfaces;

public interface IBillingService
{
    Task<List<BillingResult>> GetBillingByClientId(Guid id);

    Task<BillingResult> GetById(Guid id);

    Task<BillingResult> CreateBilling(BillingRequestDTO billing);

    Task<BillingResult> UpdateBilling(Guid id,BillingRequestDTO billingDTO);

    Task<BillingResult> DeleteBillingById(Guid id);

}
