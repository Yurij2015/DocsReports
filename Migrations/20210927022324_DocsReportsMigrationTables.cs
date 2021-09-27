using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocsReports.Migrations
{
    public partial class DocsReportsMigrationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    descripton = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DocCategories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(maxLength: 150, nullable: true),
                    description = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocCategories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_positions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ReportCategories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(maxLength: 50, nullable: true),
                    description = table.Column<string>(unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportCategories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(maxLength: 150, nullable: true),
                    phone = table.Column<string>(fixedLength: true, maxLength: 20, nullable: true),
                    email = table.Column<string>(fixedLength: true, maxLength: 100, nullable: true),
                    branchId = table.Column<int>(nullable: true),
                    postionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employees_Branches_id",
                        column: x => x.branchId,
                        principalTable: "Branches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_positions_id",
                        column: x => x.postionId,
                        principalTable: "positions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(maxLength: 150, nullable: true),
                    description = table.Column<string>(maxLength: 150, nullable: true),
                    dateadd = table.Column<DateTime>(type: "date", nullable: true),
                    employeeSend = table.Column<int>(nullable: true),
                    eployeeSent = table.Column<int>(nullable: true),
                    pageCount = table.Column<int>(nullable: true),
                    archiveId = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    docCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.id);
                    table.ForeignKey(
                        name: "FK_Documents_DocCategories_id",
                        column: x => x.docCategoryId,
                        principalTable: "DocCategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documents_Employees_id",
                        column: x => x.employeeSend,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documents_Employees_id_1",
                        column: x => x.eployeeSent,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(maxLength: 150, nullable: true),
                    description = table.Column<string>(maxLength: 150, nullable: true),
                    dateadd = table.Column<DateTime>(type: "date", nullable: true),
                    employeeSend = table.Column<int>(nullable: true),
                    employeeReceipt = table.Column<int>(nullable: true),
                    pageCount = table.Column<int>(nullable: true),
                    archiveId = table.Column<int>(nullable: true),
                    reportCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reports_Employees_id_1",
                        column: x => x.employeeReceipt,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Employees_id",
                        column: x => x.employeeSend,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_ReportCategories_id",
                        column: x => x.reportCategoryId,
                        principalTable: "ReportCategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_docCategoryId",
                table: "Documents",
                column: "docCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_employeeSend",
                table: "Documents",
                column: "employeeSend");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_eployeeSent",
                table: "Documents",
                column: "eployeeSent");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_branchId",
                table: "Employees",
                column: "branchId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_postionId",
                table: "Employees",
                column: "postionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_employeeReceipt",
                table: "Reports",
                column: "employeeReceipt");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_employeeSend",
                table: "Reports",
                column: "employeeSend");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_reportCategoryId",
                table: "Reports",
                column: "reportCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "DocCategories");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ReportCategories");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "positions");
        }
    }
}
