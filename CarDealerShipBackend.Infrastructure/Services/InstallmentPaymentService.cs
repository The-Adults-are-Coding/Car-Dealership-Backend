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
    internal class InstallmentPaymentService : IInstallmentPaymentService
    {
        private readonly ApplicationDbContext _context;
        public InstallmentPaymentService(ApplicationDbContext context) {
            _context = context;
        }
        public IEnumerable<InstallmentPayment> GetUserInstallmentPayments(int contractId)
        {
            return _context.InstallmentPayments.Where(ip=>ip.ContractId==contractId).ToList();
        }
    }
}
