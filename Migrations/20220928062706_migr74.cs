using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProject.Migrations
{
    public partial class migr74 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewOrder_OrderDetails_OrderDetailsId",
                table: "NewOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Food_FoodId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderMaster_UserId",
                table: "OrderMaster");

            migrationBuilder.DropIndex(
                name: "IX_NewOrder_OrderDetailsId",
                table: "NewOrder");

            migrationBuilder.DropIndex(
                name: "IX_Cart_FoodId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "OrderDetailsId",
                table: "NewOrder");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FoodId",
                table: "OrderDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMaster_UserId",
                table: "OrderMaster",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_FoodId",
                table: "Cart",
                column: "FoodId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Food_FoodId",
                table: "OrderDetails",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "FoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Food_FoodId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderMaster_UserId",
                table: "OrderMaster");

            migrationBuilder.DropIndex(
                name: "IX_Cart_FoodId",
                table: "Cart");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FoodId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailsId",
                table: "NewOrder",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderMaster_UserId",
                table: "OrderMaster",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewOrder_OrderDetailsId",
                table: "NewOrder",
                column: "OrderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_FoodId",
                table: "Cart",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewOrder_OrderDetails_OrderDetailsId",
                table: "NewOrder",
                column: "OrderDetailsId",
                principalTable: "OrderDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Food_FoodId",
                table: "OrderDetails",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "FoodId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
