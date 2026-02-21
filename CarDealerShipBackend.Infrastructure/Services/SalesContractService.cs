using CarDealerShipBackend.Application.Interfaces;
using CarDealerShipBackend.Domain.Entities;
using CarDealerShipBackend.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShipBackend.Infrastructure.Services
{
    public class SalesContractService : ISalesContractServices
    {
        private readonly ApplicationDbContext _context;
        public SalesContractService(ApplicationDbContext context) {
            _context = context;
        }
        public void AddNewSalesContract(SalesContract salesContract)
        {
            _context.SalesContracts.Add(salesContract);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<SalesContract>> GetAllSalesContracts()
        {
            return _context.SalesContracts.ToList();
        }

        public async Task<SalesContract> GetCarSalesContracts(int CarId)
        {
            return _context.SalesContracts.Where(s => s.CarId == CarId).First();
        }

        public async Task<IEnumerable<SalesContract>> GetUserSalesContracts(int UserId)
        {
            return _context.SalesContracts.Where(s => s.CustomerId == UserId).ToList();
        }
    }
}
