using System;

namespace CarDealerShipBackend.Application.DTOs
{
    public class BuyCarRequest
    {
        public required decimal CarId { get; set; }
        public required string PaymentType { get; set; } // "Cash" or "Installments"
        public required decimal FinalPrice { get; set; }
        public int? NumberOfInstallments { get; set; }
    }
}