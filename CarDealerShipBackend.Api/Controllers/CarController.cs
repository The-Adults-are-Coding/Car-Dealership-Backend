using CarDealerShipBackend.Application.Interfaces;
using CarDealerShipBackend.Domain.Constants;
using CarDealerShipBackend.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarDealerShipBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarServices _carService;
        public CarController(ICarServices carServices) 
        { 
            _carService=carServices;
        }
       [HttpGet("getAllCars")]
       [Authorize(Roles=Roles.Admin)]
       public async Task<IActionResult> GetAllCars()
       {
           return Ok(await _carService.GetAllCars());
       }
        [HttpGet("getFiveCars")]
        [Authorize]
        public async Task<IActionResult> GetFiveCars()
        {
            return Ok(await _carService.GetFiveCars());
        }
        [HttpGet("getAdbanner")]
        [Authorize]
        public async Task<IActionResult> GetAdBanner()
        {
            return Ok(await _carService.GetAdBanner());
        }
    }
}
