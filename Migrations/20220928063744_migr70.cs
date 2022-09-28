using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProject.Migrations
{
    public partial class migr70 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "UserListUserId",
                table: "Cart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserListUserId",
                table: "Cart",
                column: "UserListUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_UserList_UserListUserId",
                table: "Cart",
                column: "UserListUserId",
                principalTable: "UserList",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_UserList_UserListUserId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_UserListUserId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "UserListUserId",
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
    }
}
