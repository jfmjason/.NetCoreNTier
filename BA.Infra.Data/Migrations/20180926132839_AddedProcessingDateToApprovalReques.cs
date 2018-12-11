using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BA.Infra.Data.Migrations
{
    public partial class AddedProcessingDateToApprovalReques : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ProcessingDate",
                schema: "UCAF",
                table: "ApprovalRequest",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessingDate",
                schema: "UCAF",
                table: "ApprovalRequest");
        }
    }
}
