using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProject.Migrations
{
    public partial class migr38 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderDetailsId",
                table: "NewOrder",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "NewOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NewOrder_OrderDetailsId",
                table: "NewOrder",
                column: "OrderDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewOrder_OrderDetails_OrderDetailsId",
                table: "NewOrder",
                column: "OrderDetailsId",
                principalTable: "OrderDetails",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewOrder_OrderDetails_OrderDetailsId",
                table: "NewOrder");

            migrationBuilder.DropIndex(
                name: "IX_NewOrder_OrderDetailsId",
                table: "NewOrder");

            migrationBuilder.DropColumn(
                name: "OrderDetailsId",
                table: "NewOrder");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "NewOrder");
        }
    }
}
