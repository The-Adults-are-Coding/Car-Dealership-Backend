using CarDealerShipBackend.Application.DTOs;
using CarDealerShipBackend.Domain.Entities;

namespace CarDealerShipBackend.Application.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarResponse>> GetAllCarsAsync();
        Task<IEnumerable<CarResponse>> GetFiveLatestCarsAsync();
        Task<IEnumerable<CarResponse>> GetAdBannerAsync();
        Task<IEnumerable<CustomerCarResponse>> GetCarsByCustomerIdAsync(string userId);
        void AddNewCar(Car car);
    }
}