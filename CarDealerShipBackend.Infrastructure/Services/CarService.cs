<<<<<<< feature/car_service
﻿using CarDealerShipBackend.Application.Interfaces;
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

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _context.Cars
                .Where(c => c.IsSold == "N")
                .ToListAsync();
        }

        public async Task<IEnumerable<Car>> GetFiveLatestCarsAsync()
        {
            return await _context.Cars
                .Where(c => c.IsSold == "N")
                .OrderByDescending(c => c.CarId) // Or use a CreatedDate property
                .Take(5)
                .ToListAsync();
        }

        public async Task<Car> AddCarBannerAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }
}
