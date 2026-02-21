using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealerShipBackend.Domain.Entities
{

    public class SalesContract
    {
        [Key]
        public decimal ContractId { get; set; } // Primary Key

        [Required]
        [StringLength(20)]
        // [Column("CONTRACT_NUMBER")]
        public string ContractNumber { get; set; } // Unique Key

        [Required]
        // [Column("CUSTOMER_ID")]
        public decimal CustomerId { get; set; } // Foreign Key

        [Required]
        // [Column("CAR_ID")]
        public decimal CarId { get; set; } // Foreign Key

        // [Column("EMPLOYEE_ID")]

        [Required]
        // [Column("SALE_DATE")]
        public DateTime SaleDate { get; set; }

        [Required]
        [StringLength(20)]
        // [Column("PAYMENT_TYPE")]
        public string PaymentType { get; set; }

        [Required]
        // [Column("ORIGINAL_PRICE")]
        public decimal OriginalPrice { get; set; }

        // [Column("DISCOUNT_AMOUNT")]

        [Required]
        // [Column("FINAL_PRICE")]
        public decimal FinalPrice { get; set; }

        // [Column("EMPLOYEE_COMMISSION")]

        // [Column("DOWN_PAYMENT")]
        public decimal? DownPayment { get; set; }

        // [Column("REMAINING_AMOUNT")]
        public decimal? RemainingAmount { get; set; }

        // [Column("INSTALLMENT_MONTHS")]
        public int? InstallmentMonths { get; set; }

        // [Column("MONTHLY_PAYMENT")]
        public decimal? MonthlyPayment { get; set; }

        // [Column("TOTAL_AMT_INCREASE")]
        public decimal? TotalAmountIncrease { get; set; }

        // [Column("PAYMENT_DUE_DAY")]
        public int? PaymentDueDay { get; set; }

        // [Column("FIRST_PAYMENT_DATE")]
        public DateTime? FirstPaymentDate { get; set; }

        // [Column("LAST_PAYMENT_DATE")]
        public DateTime? LastPaymentDate { get; set; }

        [StringLength(20)]
        // [Column("CONTRACT_STATUS")]
        public string ContractStatus { get; set; }

        // [Column("COMPLETION_DATE")]
        public DateTime? CompletionDate { get; set; }

        public virtual ApplicationUser Customer { get; set; }
        public virtual Car Car { get; set; }
        public virtual ICollection<InstallmentPayment> Installments { get; set; }

    }

}