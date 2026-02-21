using CarDealerShipBackend.Domain.Entities;

namespace CarDealerShipBackend.Application.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task<IEnumerable<Car>> GetFiveLatestCarsAsync();
        Task<IEnumerable<Car>> GetAdBannerAsync();
    }
}