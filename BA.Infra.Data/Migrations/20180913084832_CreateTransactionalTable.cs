using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BA.Infra.Data.Migrations
{
    public partial class CreateTransactionalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "UCAF");

            migrationBuilder.CreateTable(
                name: "ApprovalRequest",
                schema: "UCAF",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    ModifiedById = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorityId = table.Column<int>(nullable: false),
                    CreationIPAddress = table.Column<string>(nullable: true),
                    ModificationIPAddress = table.Column<string>(nullable: true),
                    SMSCode = table.Column<string>(nullable: true),
                    SMSStatus = table.Column<string>(nullable: true),
                    InsuranceCardNumber = table.Column<string>(nullable: true),
                    PatientMobileNumber = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    GradeId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    PatientTypeId = table.Column<int>(nullable: false),
                    ApprovalRequestStatusId = table.Column<int>(nullable: false),
                    ApprovalRequestTypeId = table.Column<int>(nullable: false),
                    IssueAuthorityCode = table.Column<string>(nullable: true),
                    Registrationno = table.Column<int>(nullable: false),
                    RequestCreationStationId = table.Column<int>(nullable: false),
                    RequestModificationStationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalRequest_ApprovalRequestStatus_ApprovalRequestStatusId",
                        column: x => x.ApprovalRequestStatusId,
                        principalSchema: "MASTER",
                        principalTable: "ApprovalRequestStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalRequest_ApprovalRequestType_ApprovalRequestTypeId",
                        column: x => x.ApprovalRequestTypeId,
                        principalSchema: "MASTER",
                        principalTable: "ApprovalRequestType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRequest_OrganisationDetails_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "dbo",
                        principalTable: "OrganisationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalRequest_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalRequest_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRequest_Employee_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRequest_Employee_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRequest_Grade_GradeId",
                        column: x => x.GradeId,
                        principalSchema: "dbo",
                        principalTable: "Grade",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalRequest_Employee_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRequest_PatientType_PatientTypeId",
                        column: x => x.PatientTypeId,
                        principalSchema: "MASTER",
                        principalTable: "PatientType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRequest_Station_RequestCreationStationId",
                        column: x => x.RequestCreationStationId,
                        principalSchema: "dbo",
                        principalTable: "Station",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalRequest_Station_RequestModificationStationId",
                        column: x => x.RequestModificationStationId,
                        principalSchema: "dbo",
                        principalTable: "Station",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRequest_Patient_IssueAuthorityCode_Registrationno",
                        columns: x => new { x.IssueAuthorityCode, x.Registrationno },
                        principalSchema: "dbo",
                        principalTable: "Patient",
                        principalColumns: new[] { "IssueAuthorityCode", "Registrationno" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalRequestItem",
                schema: "UCAF",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    ModifiedById = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceId = table.Column<int>(nullable: true),
                    ItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ApprovedItemPrice = table.Column<decimal>(nullable: false),
                    ItemPrice = table.Column<decimal>(nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    ApprovalNumber = table.Column<string>(nullable: true),
                    ApprovalRequestItemStatusId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    TariffId = table.Column<int>(nullable: false),
                    OPBServiceId = table.Column<int>(nullable: true),
                    IPBServiceId = table.Column<int>(nullable: true),
                    ApprovalRequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRequestItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestItem_ApprovalRequest_ApprovalRequestId",
                        column: x => x.ApprovalRequestId,
                        principalSchema: "UCAF",
                        principalTable: "ApprovalRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestItem_ApprovalRequestItemStatus_ApprovalRequestItemStatusId",
                        column: x => x.ApprovalRequestItemStatusId,
                        principalSchema: "MASTER",
                        principalTable: "ApprovalRequestItemStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestItem_Employee_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestItem_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "dbo",
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestItem_IPBService_IPBServiceId",
                        column: x => x.IPBServiceId,
                        principalSchema: "dbo",
                        principalTable: "IPBService",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestItem_Employee_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestItem_OPBService_OPBServiceId",
                        column: x => x.OPBServiceId,
                        principalSchema: "dbo",
                        principalTable: "OPBService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestItem_Tariff_TariffId",
                        column: x => x.TariffId,
                        principalSchema: "dbo",
                        principalTable: "Tariff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequest_ApprovalRequestStatusId",
                schema: "UCAF",
                table: "ApprovalRequest",
                column: "ApprovalRequestStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequest_ApprovalRequestTypeId",
                schema: "UCAF",
                table: "ApprovalRequest",
                column: "ApprovalRequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequest_BranchId",
                schema: "UCAF",
                table: "ApprovalRequest",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequest_CategoryId",
                schema: "UCAF",
                table: "ApprovalRequest",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequest_CompanyId",
                schema: "UCAF",
                table: "ApprovalRequest",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequest_CreatedById",
                schema: "UCAF",
                table: "ApprovalRequest",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequest_DoctorId",
                schema: "UCAF",
                table: "ApprovalRequest",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequest_GradeId",
                schema: "UCAF",
                table: "ApprovalRequest",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequest_ModifiedById",
                schema: "UCAF",
                table: "ApprovalRequest",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequest_PatientTypeId",
                schema: "UCAF",
                table: "ApprovalRequest",
                column: "PatientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequest_RequestCreationStationId",
                schema: "UCAF",
                table: "ApprovalRequest",
                column: "RequestCreationStationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequest_RequestModificationStationId",
                schema: "UCAF",
                table: "ApprovalRequest",
                column: "RequestModificationStationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequest_IssueAuthorityCode_Registrationno",
                schema: "UCAF",
                table: "ApprovalRequest",
                columns: new[] { "IssueAuthorityCode", "Registrationno" });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestItem_ApprovalRequestId",
                schema: "UCAF",
                table: "ApprovalRequestItem",
                column: "ApprovalRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestItem_ApprovalRequestItemStatusId",
                schema: "UCAF",
                table: "ApprovalRequestItem",
                column: "ApprovalRequestItemStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestItem_CreatedById",
                schema: "UCAF",
                table: "ApprovalRequestItem",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestItem_DepartmentId",
                schema: "UCAF",
                table: "ApprovalRequestItem",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestItem_IPBServiceId",
                schema: "UCAF",
                table: "ApprovalRequestItem",
                column: "IPBServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestItem_ModifiedById",
                schema: "UCAF",
                table: "ApprovalRequestItem",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestItem_OPBServiceId",
                schema: "UCAF",
                table: "ApprovalRequestItem",
                column: "OPBServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestItem_TariffId",
                schema: "UCAF",
                table: "ApprovalRequestItem",
                column: "TariffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalRequestItem",
                schema: "UCAF");

            migrationBuilder.DropTable(
                name: "ApprovalRequest",
                schema: "UCAF");
        }
    }
}
