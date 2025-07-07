using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixPurchaseDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PurchasDate",
                table: "Assets",
                newName: "PurchaseDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PurchaseDate",
                table: "Assets",
                newName: "PurchasDate");
        }
    }
}
