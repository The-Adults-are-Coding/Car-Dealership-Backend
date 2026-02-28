using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealerShipBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PushNotifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INSTALLMENT_PAYMENTS_SALES_CONTRACTS_SalesContractContractId",
                table: "INSTALLMENT_PAYMENTS");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalesContractContractId",
                table: "INSTALLMENT_PAYMENTS",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceToken",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_INSTALLMENT_PAYMENTS_SALES_CONTRACTS_SalesContractContractId",
                table: "INSTALLMENT_PAYMENTS",
                column: "SalesContractContractId",
                principalTable: "SALES_CONTRACTS",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INSTALLMENT_PAYMENTS_SALES_CONTRACTS_SalesContractContractId",
                table: "INSTALLMENT_PAYMENTS");

            migrationBuilder.DropColumn(
                name: "DeviceToken",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalesContractContractId",
                table: "INSTALLMENT_PAYMENTS",
                type: "decimal(65,30)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AddForeignKey(
                name: "FK_INSTALLMENT_PAYMENTS_SALES_CONTRACTS_SalesContractContractId",
                table: "INSTALLMENT_PAYMENTS",
                column: "SalesContractContractId",
                principalTable: "SALES_CONTRACTS",
                principalColumn: "ContractId");
        }
    }
}
