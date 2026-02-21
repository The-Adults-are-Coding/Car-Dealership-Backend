using CarDealerShipBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShipBackend.Application.Interfaces
{
    public interface ISalesContractServices
    {
        Task<IEnumerable<SalesContract>> GetAllSalesContracts();
        Task<IEnumerable<SalesContract>> GetUserSalesContracts(int UserId);
        Task<SalesContract> GetCarSalesContracts(int CarId);
        void AddNewSalesContract(SalesContract salesContract);

    }
}
