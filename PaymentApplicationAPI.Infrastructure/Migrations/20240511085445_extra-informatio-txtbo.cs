using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentApplicationAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class extrainformatiotxtbo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ServiceOperations",
                newName: "ExtraDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExtraDetails",
                table: "ServiceOperations",
                newName: "Description");
        }
    }
}
