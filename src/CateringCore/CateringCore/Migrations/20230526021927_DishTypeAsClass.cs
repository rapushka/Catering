using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CateringCore.Migrations
{
    /// <inheritdoc />
    public partial class DishTypeAsClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Dishes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_TypeId",
                table: "Dishes",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_DishTypes_TypeId",
                table: "Dishes",
                column: "TypeId",
                principalTable: "DishTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_DishTypes_TypeId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_TypeId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Dishes");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Dishes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
