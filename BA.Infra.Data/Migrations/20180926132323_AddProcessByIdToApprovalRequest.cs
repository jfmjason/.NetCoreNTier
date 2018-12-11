using Microsoft.EntityFrameworkCore.Migrations;

namespace BA.Infra.Data.Migrations
{
    public partial class AddProcessByIdToApprovalRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProcessById",
                schema: "UCAF",
                table: "ApprovalRequest",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequest_ProcessById",
                schema: "UCAF",
                table: "ApprovalRequest",
                column: "ProcessById");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRequest_Employee_ProcessById",
                schema: "UCAF",
                table: "ApprovalRequest",
                column: "ProcessById",
                principalSchema: "dbo",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRequest_Employee_ProcessById",
                schema: "UCAF",
                table: "ApprovalRequest");

            migrationBuilder.DropIndex(
                name: "IX_ApprovalRequest_ProcessById",
                schema: "UCAF",
                table: "ApprovalRequest");

            migrationBuilder.DropColumn(
                name: "ProcessById",
                schema: "UCAF",
                table: "ApprovalRequest");
        }
    }
}
