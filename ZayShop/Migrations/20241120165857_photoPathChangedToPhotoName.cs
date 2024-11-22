using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZayShop.Migrations
{
    /// <inheritdoc />
    public partial class photoPathChangedToPhotoName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "Products",
                newName: "PhotoName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoName",
                table: "Products",
                newName: "PhotoPath");
        }
    }
}
