using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BA.Infra.Data.Migrations
{
    public partial class CreateMasterTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MASTER");

            migrationBuilder.CreateTable(
                name: "ApprovalRequestItemStatus",
                schema: "MASTER",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    ModifiedById = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRequestItemStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestItemStatus_Employee_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestItemStatus_Employee_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalRequestStatus",
                schema: "MASTER",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    ModifiedById = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRequestStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestStatus_Employee_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestStatus_Employee_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalRequestType",
                schema: "MASTER",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    ModifiedById = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRequestType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestType_Employee_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestType_Employee_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientType",
                schema: "MASTER",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    ModifiedById = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientType_Employee_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientType_Employee_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestItemStatus_CreatedById",
                schema: "MASTER",
                table: "ApprovalRequestItemStatus",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestItemStatus_ModifiedById",
                schema: "MASTER",
                table: "ApprovalRequestItemStatus",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestStatus_CreatedById",
                schema: "MASTER",
                table: "ApprovalRequestStatus",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestStatus_ModifiedById",
                schema: "MASTER",
                table: "ApprovalRequestStatus",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestType_CreatedById",
                schema: "MASTER",
                table: "ApprovalRequestType",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestType_ModifiedById",
                schema: "MASTER",
                table: "ApprovalRequestType",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_PatientType_CreatedById",
                schema: "MASTER",
                table: "PatientType",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PatientType_ModifiedById",
                schema: "MASTER",
                table: "PatientType",
                column: "ModifiedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalRequestItemStatus",
                schema: "MASTER");

            migrationBuilder.DropTable(
                name: "ApprovalRequestStatus",
                schema: "MASTER");

            migrationBuilder.DropTable(
                name: "ApprovalRequestType",
                schema: "MASTER");

            migrationBuilder.DropTable(
                name: "PatientType",
                schema: "MASTER");
        }
    }
}
