using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentApplicationAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TablesupdatedHouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Houses",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Houses");
        }
    }
}
