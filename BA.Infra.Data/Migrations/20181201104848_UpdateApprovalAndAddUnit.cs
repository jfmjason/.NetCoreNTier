using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BA.Infra.Data.Migrations
{
    public partial class UpdateApprovalAndAddUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                schema: "UCAF",
                table: "ApprovalRequest");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                schema: "UCAF",
                table: "ApprovalRequestItem",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                schema: "UCAF",
                table: "ApprovalRequestItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestItem_UnitId",
                schema: "UCAF",
                table: "ApprovalRequestItem",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRequestItem_Unit_UnitId",
                schema: "UCAF",
                table: "ApprovalRequestItem",
                column: "UnitId",
                principalSchema: "dbo",
                principalTable: "Unit",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRequestItem_Unit_UnitId",
                schema: "UCAF",
                table: "ApprovalRequestItem");

            migrationBuilder.DropIndex(
                name: "IX_ApprovalRequestItem_UnitId",
                schema: "UCAF",
                table: "ApprovalRequestItem");

            migrationBuilder.DropColumn(
                name: "OrderId",
                schema: "UCAF",
                table: "ApprovalRequestItem");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                schema: "UCAF",
                table: "ApprovalRequestItem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                schema: "UCAF",
                table: "ApprovalRequest",
                nullable: false,
                defaultValue: 0);
        }
    }
}
