using CarDealerShipBackend.Application.Interfaces;
using CarDealerShipBackend.Domain.Constants;
using CarDealerShipBackend.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerShipBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ICarServices _carServices;
        public readonly ISalesContractServices _salesContractServices;
        public AdminController(ICarServices carServices, ISalesContractServices salesContractServices)
        {
            _carServices = carServices;
            _salesContractServices = salesContractServices;
        }
        [HttpGet("getAllCars")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> getAllCars()
        {
            return Ok(value: await _carServices.GetAllCars());
        }
        [HttpGet("getAllSalesContracts")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> getAllSalesContracts() {
            return Ok(await _salesContractServices.GetAllSalesContracts());
        }
        [HttpGet("getUserContracts/{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> getUserSalesContracts(int id) {
            return Ok(await _salesContractServices.GetUserSalesContracts(id));
        }
        [HttpGet("getCarContract/{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> getCarSalesContract(int id) {
            return Ok(await _salesContractServices.GetCarSalesContracts(id));
        }
        [HttpPost("addNewContract")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> addNewSalesContract([FromBody] SalesContract contract) 
        {
            _salesContractServices.AddNewSalesContract(contract);
            return Ok();
        }
    }
}
