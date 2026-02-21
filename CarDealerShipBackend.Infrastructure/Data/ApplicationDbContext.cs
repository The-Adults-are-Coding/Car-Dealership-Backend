using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealerShipBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace CarDealerShipBackend.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<SalesContract> SalesContracts { get; set; }
        public DbSet<InstallmentPayment> InstallmentPayments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // 1. CARS Configuration
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("CARS");
                entity.HasKey(e => e.CarId);
            });

            // 2. SALES_CONTRACTS Configuration
            modelBuilder.Entity<SalesContract>(entity =>
            {
                entity.ToTable("SALES_CONTRACTS");
                entity.HasKey(e => e.ContractId);
                entity.HasIndex(e => e.ContractNumber).IsUnique();

                // Relationship: One Contract has many Installments

            });

            // 3. INSTALLMENT_PAYMENTS Configuration
            modelBuilder.Entity<InstallmentPayment>(entity =>
            {
                entity.ToTable("INSTALLMENT_PAYMENTS");
                entity.HasKey(e => e.PaymentId);

                // Composite Unique Index (ContractID + PaymentNumber)
                entity.HasIndex(e => new { e.ContractId, e.PaymentNumber })
                      .HasDatabaseName("UK_PMT_CONT_NUM")
                      .IsUnique();
            });
        }

    }
}