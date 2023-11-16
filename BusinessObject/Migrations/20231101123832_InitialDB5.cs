using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBook_Books_Book_Id",
                table: "UserBook");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBook_Users_User_Id",
                table: "UserBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBook",
                table: "UserBook");

            migrationBuilder.RenameTable(
                name: "UserBook",
                newName: "userBooks");

            migrationBuilder.RenameIndex(
                name: "IX_UserBook_Book_Id",
                table: "userBooks",
                newName: "IX_userBooks_Book_Id");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_userBooks",
                table: "userBooks",
                columns: new[] { "User_Id", "Book_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_userBooks_Books_Book_Id",
                table: "userBooks",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userBooks_Users_User_Id",
                table: "userBooks",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "User_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userBooks_Books_Book_Id",
                table: "userBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_userBooks_Users_User_Id",
                table: "userBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userBooks",
                table: "userBooks");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "userBooks",
                newName: "UserBook");

            migrationBuilder.RenameIndex(
                name: "IX_userBooks_Book_Id",
                table: "UserBook",
                newName: "IX_UserBook_Book_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBook",
                table: "UserBook",
                columns: new[] { "User_Id", "Book_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserBook_Books_Book_Id",
                table: "UserBook",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBook_Users_User_Id",
                table: "UserBook",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "User_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
