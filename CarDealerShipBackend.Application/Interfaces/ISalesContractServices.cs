using CarDealerShipBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealerShipBackend.Application.DTOs; // Required for PaginatedResult
using CarDealerShipBackend.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealerShipBackend.Application.Interfaces
{
    public interface ISalesContractServices
    {
        // Updated to support Pagination
        Task<PaginatedResult<SalesContract>> GetAllSalesContracts(int pageNumber, int pageSize);

        Task<IEnumerable<SalesContract>> GetUserSalesContracts(int UserId);
        Task<SalesContract> GetCarSalesContracts(int CarId);
        void AddNewSalesContract(SalesContract salesContract);
    }
}