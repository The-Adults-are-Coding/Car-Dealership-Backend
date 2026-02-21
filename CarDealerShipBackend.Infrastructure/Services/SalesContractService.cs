using CarDealerShipBackend.Application.Interfaces;
using CarDealerShipBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShipBackend.Infrastructure.Services
{
    internal class SalesContractService : ISalesContractServices
    {
        public Task<IEnumerable<SalesContract>> GetAllSalesContracts()
        {
            throw new NotImplementedException();
        }

        public Task<SalesContract> GetCarSalesContracts(int CarId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SalesContract>> GetUserSalesContracts(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
