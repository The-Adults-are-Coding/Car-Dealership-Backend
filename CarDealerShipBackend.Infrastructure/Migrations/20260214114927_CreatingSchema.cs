using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealerShipBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatingSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CARS",
                columns: table => new
                {
                    CarId = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Manufacturer = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModelName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CarYear = table.Column<int>(type: "int", nullable: false),
                    RegistrationYear = table.Column<int>(type: "int", nullable: true),
                    Color = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CarCondition = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    IsSold = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SoldDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Mileage = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARS", x => x.CarId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "INSTALLMENT_PAYMENTS",
                columns: table => new
                {
                    PaymentId = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ContractId = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PaymentNumber = table.Column<int>(type: "int", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ScheduledAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ActualPaymentDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ActualAmountPaid = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    DaysLate = table.Column<int>(type: "int", nullable: true),
                    LatePenalty = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    TotalAmountPaid = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentMethod = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSTALLMENT_PAYMENTS", x => x.PaymentId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SALES_CONTRACTS",
                columns: table => new
                {
                    ContractId = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ContractNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerId = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CarId = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PaymentType = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OriginalPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DownPayment = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    RemainingAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    InstallmentMonths = table.Column<int>(type: "int", nullable: true),
                    MonthlyPayment = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    TotalAmountIncrease = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    PaymentDueDay = table.Column<int>(type: "int", nullable: true),
                    FirstPaymentDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastPaymentDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ContractStatus = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompletionDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALES_CONTRACTS", x => x.ContractId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "UK_PMT_CONT_NUM",
                table: "INSTALLMENT_PAYMENTS",
                columns: new[] { "ContractId", "PaymentNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SALES_CONTRACTS_ContractNumber",
                table: "SALES_CONTRACTS",
                column: "ContractNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CARS");

            migrationBuilder.DropTable(
                name: "INSTALLMENT_PAYMENTS");

            migrationBuilder.DropTable(
                name: "SALES_CONTRACTS");
        }
    }
}
