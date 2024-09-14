using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApi.Migrations
{
    /// <inheritdoc />
    public partial class addprop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Properties",
                table: "Properties");

            migrationBuilder.RenameTable(
                name: "Properties",
                newName: "properties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_properties",
                table: "properties",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_properties_User_Id",
                table: "properties",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_properties_users_User_Id",
                table: "properties",
                column: "User_Id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_properties_users_User_Id",
                table: "properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_properties",
                table: "properties");

            migrationBuilder.DropIndex(
                name: "IX_properties_User_Id",
                table: "properties");

            migrationBuilder.RenameTable(
                name: "properties",
                newName: "Properties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Properties",
                table: "Properties",
                column: "Id");
        }
    }
}
