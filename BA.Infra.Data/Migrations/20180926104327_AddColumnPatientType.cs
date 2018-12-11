using Microsoft.EntityFrameworkCore.Migrations;

namespace BA.Infra.Data.Migrations
{
    public partial class AddColumnPatientType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "MASTER",
                table: "PatientType",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                schema: "MASTER",
                table: "PatientType");
        }
    }
}
