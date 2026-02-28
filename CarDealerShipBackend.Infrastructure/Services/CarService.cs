using CarDealerShipBackend.Application.DTOs;
using CarDealerShipBackend.Application.Interfaces;
using CarDealerShipBackend.Domain.Entities;
using CarDealerShipBackend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CarDealerShipBackend.Infrastructure.Services
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;

        public CarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedResult<CarResponse>> GetAllCarsAsync(int pageNumber, int pageSize)
        {
            var query = _context.Cars.Where(c => c.IsSold == "N");

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(c => c.CarId) 
                .Skip((pageNumber - 1) * pageSize) 
                .Take(pageSize) 
                .Select(c => new CarResponse(
                    c.CarId,
                    c.Manufacturer,
                    c.ModelName,
                    c.CarYear,
                    c.Color,
                    c.CarCondition,
                    c.Price,
                    c.Mileage
                ))
                .ToListAsync();

            return new PaginatedResult<CarResponse>
            {

                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<IEnumerable<CarResponse>> GetFiveLatestCarsAsync()
        {
            return await _context.Cars
                .Where(c => c.IsSold == "N")
                .OrderByDescending(c => c.CarId)
                .Take(5)
                .Select(c => new CarResponse(
                    c.CarId,
                    c.Manufacturer,
                    c.ModelName,
                    c.CarYear,
                    c.Color,
                    c.CarCondition,
                    c.Price,
                    c.Mileage
                ))
                .ToListAsync();
        }

        public async Task<IEnumerable<CarResponse>> GetAdBannerAsync()
        {
            return await _context.Cars
                .Where(c => c.IsSold == "N")
                .OrderByDescending(c => c.CarId)
                .Take(5)
                .Select(c => new CarResponse(
                    c.CarId,
                    c.Manufacturer,
                    c.ModelName,
                    c.CarYear,
                    c.Color,
                    c.CarCondition,
                    c.Price,
                    c.Mileage
                ))
                .ToListAsync();
        }
        public async Task<IEnumerable<CustomerCarResponse>> GetCarsByCustomerIdAsync(string userId)
        {
            return await _context.SalesContracts
                .Where(sc => sc.Customer.Id == userId) 
                .Select(sc => new CustomerCarResponse(
                    sc.Car.CarId,
                    sc.Car.Manufacturer,
                    sc.Car.ModelName,
                    sc.Car.CarYear,
                    sc.Car.Price,
                    sc.ContractNumber,
                    sc.SaleDate
                ))
                .ToListAsync();
        }
        public void AddNewCar(Car car) 
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }
    }
}