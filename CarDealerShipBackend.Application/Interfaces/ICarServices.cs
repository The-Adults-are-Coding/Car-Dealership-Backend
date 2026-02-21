using CarDealerShipBackend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShipBackend.Application.Interfaces
{
    public interface ICarServices
    {
         Task<IEnumerable<Car>> GetAllCars();
         Task<IEnumerable<Car>> GetFiveCars();
         Task<IEnumerable<Car>> GetAdBanner();
    }
}
