using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsAttributesRestApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Products");
        }
    }
}
