using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CarDealerShipBackend.Application.Interfaces;
using CarDealerShipBackend.Application.DTOs;

namespace CarDealerShipBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // This ensures the whole controller requires a login token
    public class CustomerController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly ISalesService _salesService;

        public CustomerController(ICarService carService, ISalesService salesService)
        {
            _carService = carService;
            _salesService = salesService;
        }

        [HttpGet("my-cars")]
        public async Task<IActionResult> GetMyCars()
        {
            // We pull the 'uid' claim that you defined in AuthService.GenerateAuthResponse
            var userId = User.FindFirstValue("uid");

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User ID not found in token." });
            }

            var cars = await _carService.GetCarsByCustomerIdAsync(userId);
            return Ok(cars);
        }

        [HttpPost("buy")]
        public async Task<IActionResult> BuyCar([FromBody] BuyCarRequest request)
        {
            var userId = User.FindFirstValue("uid");

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User ID not found in token." });
            }

            var success = await _salesService.ProcessPurchaseAsync(userId, request);

            if (!success)
            {
                return BadRequest(new { message = "Purchase failed. The car might already be sold or does not exist." });
            }

            return Ok(new { message = "Congratulations! Your purchase has been processed." });
        }

        [HttpGet("my-installments")]
        public async Task<IActionResult> GetMyInstallments()
        {
            var userId = User.FindFirstValue("uid");

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User ID not found in token." });
            }

            var installments = await _salesService.GetUserInstallmentsAsync(userId);
            return Ok(installments);
        }
    }
}