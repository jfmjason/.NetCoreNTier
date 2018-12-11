using Microsoft.EntityFrameworkCore.Migrations;

namespace BA.Infra.Data.Migrations
{
    public partial class UpdateRequestItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                schema: "UCAF",
                table: "ApprovalRequestItem",
                newName: "RequestedQuantity");

            migrationBuilder.RenameColumn(
                name: "ApprovedItemPrice",
                schema: "UCAF",
                table: "ApprovalRequestItem",
                newName: "RequestedAmount");

            migrationBuilder.AddColumn<decimal>(
                name: "ApprovedAmount",
                schema: "UCAF",
                table: "ApprovalRequestItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ApprovedQuantity",
                schema: "UCAF",
                table: "ApprovalRequestItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                schema: "UCAF",
                table: "ApprovalRequestItem",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedAmount",
                schema: "UCAF",
                table: "ApprovalRequestItem");

            migrationBuilder.DropColumn(
                name: "ApprovedQuantity",
                schema: "UCAF",
                table: "ApprovalRequestItem");

            migrationBuilder.DropColumn(
                name: "UnitId",
                schema: "UCAF",
                table: "ApprovalRequestItem");

            migrationBuilder.RenameColumn(
                name: "RequestedQuantity",
                schema: "UCAF",
                table: "ApprovalRequestItem",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "RequestedAmount",
                schema: "UCAF",
                table: "ApprovalRequestItem",
                newName: "ApprovedItemPrice");
        }
    }
}
