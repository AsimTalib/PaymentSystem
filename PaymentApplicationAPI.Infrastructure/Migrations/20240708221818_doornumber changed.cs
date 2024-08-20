using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentApplicationAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class doornumberchanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Houses",
                newName: "DoorNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DoorNumber",
                table: "Houses",
                newName: "Number");
        }
    }
}
