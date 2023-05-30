using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CateringCore.Migrations
{
    /// <inheritdoc />
    public partial class OrderDateAddedToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Orders",
                newName: "OrderDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "FulfillmentDate",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FulfillmentDate",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Orders",
                newName: "Date");
        }
    }
}
