using CarDealerShipBackend.Application.DTOs;
using CarDealerShipBackend.Domain.Entities;

namespace CarDealerShipBackend.Application.Interfaces
{
    public interface ICarService
    {
        Task<PaginatedResult<CarResponse>> GetAllCarsAsync(int pageNumber, int pageSize);
        Task<IEnumerable<CarResponse>> GetFiveLatestCarsAsync();
        Task<IEnumerable<CarResponse>> GetAdBannerAsync();
        Task<IEnumerable<CustomerCarResponse>> GetCarsByCustomerIdAsync(string userId);
        void AddNewCar(Car car);
    }
}