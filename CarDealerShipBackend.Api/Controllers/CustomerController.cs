using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CarDealerShipBackend.Application.Interfaces;

namespace CarDealerShipBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // This ensures the whole controller requires a login token
    public class CustomerController : ControllerBase
    {
        private readonly ICarService _carService;

        public CustomerController(ICarService carService)
        {
            _carService = carService;
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
    }
}