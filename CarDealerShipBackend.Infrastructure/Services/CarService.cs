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

        public async Task<IEnumerable<CarResponse>> GetAllCarsAsync()
        {
            return await _context.Cars
                .Where(c => c.IsSold == "N")
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