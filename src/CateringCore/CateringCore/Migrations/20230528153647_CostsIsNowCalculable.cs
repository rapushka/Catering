using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CateringCore.Migrations
{
    /// <inheritdoc />
    public partial class CostsIsNowCalculable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "FoodsInOrders");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "DishesInOrders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "FoodsInOrders",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "DishesInOrders",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
