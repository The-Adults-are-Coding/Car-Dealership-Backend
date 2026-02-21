using CarDealerShipBackend.Application.Interfaces;
using CarDealerShipBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShipBackend.Infrastructure.Services
{
    public class CarService : ICarServices
    {
        public CarService() { }
        public Task<IEnumerable<Car>> GetAdBanner()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Car>> GetAllCars()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Car>> GetFiveCars()
        {
            throw new NotImplementedException();
        }
    }
}
