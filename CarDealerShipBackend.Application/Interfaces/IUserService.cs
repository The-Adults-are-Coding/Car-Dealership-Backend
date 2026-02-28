using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShipBackend.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> UpdateUserDeviceTokenAsync(string userId, string deviceToken);
        Task<double> getBalanceAsync(string id);
    }
}
