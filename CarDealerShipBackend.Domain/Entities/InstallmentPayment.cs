using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealerShipBackend.Domain.Entities
{
    public class InstallmentPayment
    {
        [Key]
        // [Column("PAYMENT_ID")]
        public decimal PaymentId { get; set; } // Primary Key

        [Required]
        // [Column("CONTRACT_ID")]
        public decimal ContractId { get; set; } // Foreign Key (FK_PMT_CONT)

        [Required]
        // [Column("PAYMENT_NUMBER")]
        public int PaymentNumber { get; set; } // Unique Key Part (UK_PMT_CONT_NUM)

        [Required]
        // [Column("SCHEDULED_DATE")]
        public DateTime ScheduledDate { get; set; }

        [Required]
        // [Column("SCHEDULED_AMOUNT")]
        public decimal ScheduledAmount { get; set; }

        // [Column("ACTUAL_PAYMENT_DATE")]
        public DateTime? ActualPaymentDate { get; set; }

        // [Column("ACTUAL_AMOUNT_PAID")]
        public decimal? ActualAmountPaid { get; set; }

        // [Column("DAYS_LATE")]
        public int? DaysLate { get; set; }

        // [Column("LATE_PENALTY")]
        public decimal? LatePenalty { get; set; }

        // [Column("TOTAL_AMOUNT_PAID")]
        public decimal? TotalAmountPaid { get; set; }

        [StringLength(20)]
        // [Column("PAYMENT_STATUS")]
        public string PaymentStatus { get; set; }

        [StringLength(20)]
        // [Column("PAYMENT_METHOD")]
        public string PaymentMethod { get; set; }

        public virtual SalesContract SalesContract { get; set; } 
        // The following two fields are partially obscured but inferred from data types:

    }
}