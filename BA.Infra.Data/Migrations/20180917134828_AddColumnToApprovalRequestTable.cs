using Microsoft.EntityFrameworkCore.Migrations;

namespace BA.Infra.Data.Migrations
{
    public partial class AddColumnToApprovalRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IPId",
                schema: "UCAF",
                table: "ApprovalRequest",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                schema: "UCAF",
                table: "ApprovalRequest",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IPId",
                schema: "UCAF",
                table: "ApprovalRequest");

            migrationBuilder.DropColumn(
                name: "OrderId",
                schema: "UCAF",
                table: "ApprovalRequest");
        }
    }
}
