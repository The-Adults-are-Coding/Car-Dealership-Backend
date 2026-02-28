using CarDealerShipBackend.Application.Interfaces;
using CarDealerShipBackend.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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
    }
}
