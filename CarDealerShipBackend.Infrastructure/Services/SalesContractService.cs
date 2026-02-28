using CarDealerShipBackend.Application.DTOs; // Required for PaginatedResult
using CarDealerShipBackend.Application.Interfaces;
using CarDealerShipBackend.Domain.Entities;
using CarDealerShipBackend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore; // Required for CountAsync() and ToListAsync()
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealerShipBackend.Infrastructure.Services
{
    public class SalesContractService : ISalesContractServices
    {
        private readonly ApplicationDbContext _context;

        public SalesContractService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddNewSalesContract(SalesContract salesContract)
        {
            _context.SalesContracts.Add(salesContract);
            _context.SaveChanges();
        }

        // Updated Method with Pagination Logic
        public async Task<PaginatedResult<SalesContract>> GetAllSalesContracts(int pageNumber, int pageSize)
        {
            // 1. Prepare the base query
            var query = _context.SalesContracts.AsQueryable();

            // 2. Get the total count of records in the database
            var totalCount = await query.CountAsync();

            // 3. Fetch only the required page data
            var items = await query
                .OrderByDescending(s => s.SaleDate) // Always order before pagination to ensure predictable results
                .Skip((pageNumber - 1) * pageSize)  // Skip records from previous pages
                .Take(pageSize)                     // Take only the number of records for the current page
                .ToListAsync();                     // Execute query asynchronously

            // 4. Return the formatted paginated result
            return new PaginatedResult<SalesContract>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<SalesContract> GetCarSalesContracts(int CarId)
        {
            return await _context.SalesContracts.Where(s => s.CarId == CarId).FirstAsync();
        }

        public async Task<IEnumerable<SalesContract>> GetUserSalesContracts(int UserId)
        {
            return await _context.SalesContracts.Where(s => s.CustomerId == UserId).ToListAsync();
        }
    }
}