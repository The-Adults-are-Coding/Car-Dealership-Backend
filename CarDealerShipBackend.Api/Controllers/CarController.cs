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

        public async Task<IActionResult> GetAllCars([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;
            if (pageSize > 50) pageSize = 50; 

            var result = await _carService.GetAllCarsAsync(pageNumber, pageSize);
            return Ok(result);
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
