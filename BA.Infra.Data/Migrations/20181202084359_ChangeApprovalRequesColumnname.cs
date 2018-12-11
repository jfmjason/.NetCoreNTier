using Microsoft.EntityFrameworkCore.Migrations;

namespace BA.Infra.Data.Migrations
{
    public partial class ChangeApprovalRequesColumnname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PatientMobileNumber",
                schema: "UCAF",
                table: "ApprovalRequest",
                newName: "ContactNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactNumber",
                schema: "UCAF",
                table: "ApprovalRequest",
                newName: "PatientMobileNumber");
        }
    }
}
