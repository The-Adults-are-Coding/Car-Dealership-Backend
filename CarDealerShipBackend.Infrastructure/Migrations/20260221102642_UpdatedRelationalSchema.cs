using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealerShipBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRelationalSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerId1",
                table: "SALES_CONTRACTS",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "SalesContractContractId",
                table: "INSTALLMENT_PAYMENTS",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SALES_CONTRACTS_CarId",
                table: "SALES_CONTRACTS",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_SALES_CONTRACTS_CustomerId1",
                table: "SALES_CONTRACTS",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_INSTALLMENT_PAYMENTS_SalesContractContractId",
                table: "INSTALLMENT_PAYMENTS",
                column: "SalesContractContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_INSTALLMENT_PAYMENTS_SALES_CONTRACTS_SalesContractContractId",
                table: "INSTALLMENT_PAYMENTS",
                column: "SalesContractContractId",
                principalTable: "SALES_CONTRACTS",
                principalColumn: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_SALES_CONTRACTS_AspNetUsers_CustomerId1",
                table: "SALES_CONTRACTS",
                column: "CustomerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SALES_CONTRACTS_CARS_CarId",
                table: "SALES_CONTRACTS",
                column: "CarId",
                principalTable: "CARS",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INSTALLMENT_PAYMENTS_SALES_CONTRACTS_SalesContractContractId",
                table: "INSTALLMENT_PAYMENTS");

            migrationBuilder.DropForeignKey(
                name: "FK_SALES_CONTRACTS_AspNetUsers_CustomerId1",
                table: "SALES_CONTRACTS");

            migrationBuilder.DropForeignKey(
                name: "FK_SALES_CONTRACTS_CARS_CarId",
                table: "SALES_CONTRACTS");

            migrationBuilder.DropIndex(
                name: "IX_SALES_CONTRACTS_CarId",
                table: "SALES_CONTRACTS");

            migrationBuilder.DropIndex(
                name: "IX_SALES_CONTRACTS_CustomerId1",
                table: "SALES_CONTRACTS");

            migrationBuilder.DropIndex(
                name: "IX_INSTALLMENT_PAYMENTS_SalesContractContractId",
                table: "INSTALLMENT_PAYMENTS");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "SALES_CONTRACTS");

            migrationBuilder.DropColumn(
                name: "SalesContractContractId",
                table: "INSTALLMENT_PAYMENTS");
        }
    }
}
