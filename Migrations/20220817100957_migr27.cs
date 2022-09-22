using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProject.Migrations
{
    public partial class migr27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_UserList_UserId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_UserId",
                table: "Cart");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "UserList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserList_CartId",
                table: "UserList",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserList_Cart_CartId",
                table: "UserList",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "CartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserList_Cart_CartId",
                table: "UserList");

            migrationBuilder.DropIndex(
                name: "IX_UserList_CartId",
                table: "UserList");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "UserList");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_UserList_UserId",
                table: "Cart",
                column: "UserId",
                principalTable: "UserList",
                principalColumn: "UserId");
        }
    }
}
