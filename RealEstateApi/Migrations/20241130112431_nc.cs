using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApi.Migrations
{
    /// <inheritdoc />
    public partial class nc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Property_Id",
                table: "Gallary",
                newName: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Gallary_PropertyId",
                table: "Gallary",
                column: "PropertyId");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropIndex(
                name: "IX_Gallary_PropertyId",
                table: "Gallary");

            migrationBuilder.RenameColumn(
                name: "PropertyId",
                table: "Gallary",
                newName: "Property_Id");
        }
    }
}
