using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentApplicationAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HouseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membership_House_HouseId",
                table: "Membership");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOperations_Membership_MembershipId",
                table: "ServiceOperations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Membership",
                table: "Membership");

            migrationBuilder.DropPrimaryKey(
                name: "PK_House",
                table: "House");

            migrationBuilder.RenameTable(
                name: "Membership",
                newName: "Memberships");

            migrationBuilder.RenameTable(
                name: "House",
                newName: "Houses");

            migrationBuilder.RenameIndex(
                name: "IX_Membership_HouseId",
                table: "Memberships",
                newName: "IX_Memberships_HouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Memberships",
                table: "Memberships",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Houses",
                table: "Houses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Houses_HouseId",
                table: "Memberships",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOperations_Memberships_MembershipId",
                table: "ServiceOperations",
                column: "MembershipId",
                principalTable: "Memberships",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Houses_HouseId",
                table: "Memberships");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOperations_Memberships_MembershipId",
                table: "ServiceOperations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Memberships",
                table: "Memberships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Houses",
                table: "Houses");

            migrationBuilder.RenameTable(
                name: "Memberships",
                newName: "Membership");

            migrationBuilder.RenameTable(
                name: "Houses",
                newName: "House");

            migrationBuilder.RenameIndex(
                name: "IX_Memberships_HouseId",
                table: "Membership",
                newName: "IX_Membership_HouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Membership",
                table: "Membership",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_House",
                table: "House",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Membership_House_HouseId",
                table: "Membership",
                column: "HouseId",
                principalTable: "House",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOperations_Membership_MembershipId",
                table: "ServiceOperations",
                column: "MembershipId",
                principalTable: "Membership",
                principalColumn: "Id");
        }
    }
}
