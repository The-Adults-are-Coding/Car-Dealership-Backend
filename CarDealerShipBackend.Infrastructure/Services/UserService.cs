using CarDealerShipBackend.Application.Interfaces;
using CarDealerShipBackend.Domain.Entities;
using CarDealerShipBackend.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShipBackend.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> UpdateUserDeviceTokenAsync(string userId, string deviceToken)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            user.DeviceToken = deviceToken;
            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }
        public async Task<double> getBalanceAsync(string id) {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return 0;
            double balance = user.balance;
            return balance;
        }
    }
}
