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
        private readonly ICarService _carServices;
        private readonly ISalesContractServices _salesContractServices;
        private readonly IInstallmentPaymentService _installmentPaymentService;
        public AdminController(
            ICarService carServices,
            ISalesContractServices salesContractServices,
            IInstallmentPaymentService installmentPaymentService
            )
        {
            _carServices = carServices;
            _salesContractServices = salesContractServices;
            _installmentPaymentService = installmentPaymentService;
        }
        [HttpGet("getAllCars")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> GetAllCars([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;
            if (pageSize > 50) pageSize = 50;

            var result = await _carServices.GetAllCarsAsync(pageNumber, pageSize);
            return Ok(result);
        }
        [HttpGet("getAllSalesContracts")]
        [Authorize(Roles = Roles.Admin)]

        public async Task<IActionResult> GetAllSalesContracts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            // Validate inputs to prevent negative numbers or excessively large queries
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;
            if (pageSize > 50) pageSize = 50; // Max 50 records per request to protect server memory

            var result = await _salesContractServices.GetAllSalesContracts(pageNumber, pageSize);

            return Ok(result);
        }

            [HttpGet("getUserContracts/{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> getUserSalesContracts(int id)
        {
            return Ok(await _salesContractServices.GetUserSalesContracts(id));
        }
        [HttpGet("getCarContract/{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> getCarSalesContract(int id)
        {
            return Ok(await _salesContractServices.GetCarSalesContracts(id));
        }
        [HttpPost("addNewContract")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> addNewSalesContract([FromBody] SalesContract contract)
        {
            _salesContractServices.AddNewSalesContract(contract);
            return Ok();
        }
        [HttpPost("addNewCar")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> addNewCar([FromBody] Car newCar) {
            _carServices.AddNewCar(newCar);
            return Ok();
        }
        [HttpGet("ContractPayment/{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> getContractPayment(int id) {
            return Ok( _installmentPaymentService.GetUserInstallmentPayments(id));
        }
    }
}
