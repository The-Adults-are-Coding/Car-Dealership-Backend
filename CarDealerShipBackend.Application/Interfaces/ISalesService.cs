using CarDealerShipBackend.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealerShipBackend.Application.Interfaces
{
    public interface ISalesService
    {
        Task<bool> ProcessPurchaseAsync(string userId, BuyCarRequest request);
        Task<IEnumerable<InstallmentResponse>> GetUserInstallmentsAsync(string userId);
    }
}