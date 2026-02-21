using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealerShipBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCarIdToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SALES_CONTRACTS_CARS_CarId",
                table: "SALES_CONTRACTS");

            migrationBuilder.DropIndex(
                name: "IX_SALES_CONTRACTS_CarId",
                table: "SALES_CONTRACTS");

            migrationBuilder.AddColumn<int>(
                name: "CarId1",
                table: "SALES_CONTRACTS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "CARS",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_SALES_CONTRACTS_CarId1",
                table: "SALES_CONTRACTS",
                column: "CarId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SALES_CONTRACTS_CARS_CarId1",
                table: "SALES_CONTRACTS",
                column: "CarId1",
                principalTable: "CARS",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SALES_CONTRACTS_CARS_CarId1",
                table: "SALES_CONTRACTS");

            migrationBuilder.DropIndex(
                name: "IX_SALES_CONTRACTS_CarId1",
                table: "SALES_CONTRACTS");

            migrationBuilder.DropColumn(
                name: "CarId1",
                table: "SALES_CONTRACTS");

            migrationBuilder.AlterColumn<decimal>(
                name: "CarId",
                table: "CARS",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_SALES_CONTRACTS_CarId",
                table: "SALES_CONTRACTS",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_SALES_CONTRACTS_CARS_CarId",
                table: "SALES_CONTRACTS",
                column: "CarId",
                principalTable: "CARS",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
