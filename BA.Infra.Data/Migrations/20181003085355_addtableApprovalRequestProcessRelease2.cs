using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BA.Infra.Data.Migrations
{
    public partial class addtableApprovalRequestProcessRelease2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApprovalRequestProcessRelease",
                schema: "UCAF",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    IpAddress = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    CurrentProcessOwnerId = table.Column<int>(nullable: false),
                    AssignToEmployeeId = table.Column<int>(nullable: true),
                    ReleasedByEmployeeId = table.Column<int>(nullable: false),
                    ApprovalRequestId = table.Column<int>(nullable: false),
                    StationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRequestProcessRelease", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestProcessRelease_ApprovalRequest_ApprovalRequestId",
                        column: x => x.ApprovalRequestId,
                        principalSchema: "UCAF",
                        principalTable: "ApprovalRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestProcessRelease_Employee_AssignToEmployeeId",
                        column: x => x.AssignToEmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestProcessRelease_Employee_CurrentProcessOwnerId",
                        column: x => x.CurrentProcessOwnerId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestProcessRelease_Employee_ReleasedByEmployeeId",
                        column: x => x.ReleasedByEmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestProcessRelease_Station_StationId",
                        column: x => x.StationId,
                        principalSchema: "dbo",
                        principalTable: "Station",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestProcessRelease_ApprovalRequestId",
                schema: "UCAF",
                table: "ApprovalRequestProcessRelease",
                column: "ApprovalRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestProcessRelease_AssignToEmployeeId",
                schema: "UCAF",
                table: "ApprovalRequestProcessRelease",
                column: "AssignToEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestProcessRelease_CurrentProcessOwnerId",
                schema: "UCAF",
                table: "ApprovalRequestProcessRelease",
                column: "CurrentProcessOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestProcessRelease_ReleasedByEmployeeId",
                schema: "UCAF",
                table: "ApprovalRequestProcessRelease",
                column: "ReleasedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestProcessRelease_StationId",
                schema: "UCAF",
                table: "ApprovalRequestProcessRelease",
                column: "StationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalRequestProcessRelease",
                schema: "UCAF");
        }
    }
}
