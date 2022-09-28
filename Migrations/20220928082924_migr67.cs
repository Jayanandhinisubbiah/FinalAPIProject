using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProject.Migrations
{
    public partial class migr67 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderMasterOrderId",
                table: "NewOrder",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewOrder_OrderMasterOrderId",
                table: "NewOrder",
                column: "OrderMasterOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewOrder_OrderMaster_OrderMasterOrderId",
                table: "NewOrder",
                column: "OrderMasterOrderId",
                principalTable: "OrderMaster",
                principalColumn: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewOrder_OrderMaster_OrderMasterOrderId",
                table: "NewOrder");

            migrationBuilder.DropIndex(
                name: "IX_NewOrder_OrderMasterOrderId",
                table: "NewOrder");

            migrationBuilder.DropColumn(
                name: "OrderMasterOrderId",
                table: "NewOrder");
        }
    }
}
