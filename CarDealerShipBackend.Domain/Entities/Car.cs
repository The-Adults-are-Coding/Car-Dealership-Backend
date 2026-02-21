using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealerShipBackend.Domain.Entities
{
    public class Car
    {
        [Key]
        public decimal CarId { get; set; }

        [Required]
        [StringLength(50)]
        public string Manufacturer { get; set; }

        [Required]
        [StringLength(100)]
        public string ModelName { get; set; }

        public int CarYear { get; set; }

        public int? RegistrationYear { get; set; }

        [Required]
        [StringLength(30)]
        public string Color { get; set; }


        [Required]
        [StringLength(10)]
        public string CarCondition { get; set; }

        public decimal? Price { get; set; }
        public string IsSold { get; set; } // CHAR(1) - usually 'Y'/'N' or '1'/'0'

        public DateTime? SoldDate { get; set; }
        public long? Mileage { get; set; }
    }
}