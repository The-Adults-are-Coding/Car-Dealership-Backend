using CarDealerShipBackend.Application.Interfaces;
using CarDealerShipBackend.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerShipBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carServices)
        {
            _carService = carServices;
        }
        [HttpGet("getAllCars")]
        [Authorize]
        public async Task<IActionResult> GetAllCars()
        {
            return Ok(await _carService.GetAllCarsAsync());
        }
        [HttpGet("getFiveCars")]
        [Authorize]
        public async Task<IActionResult> GetFiveCars()
        {
            return Ok(await _carService.GetFiveLatestCarsAsync());
        }
        [HttpGet("getAdbanner")]
        [Authorize]
        public async Task<IActionResult> GetAdBanner()
        {
            return Ok(await _carService.GetAdBannerAsync());
        }
    }
}
