using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECA.API.Migrations
{
    /// <inheritdoc />
    public partial class User_SYSWS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemWorkstations",
                columns: table => new
                {
                    SYSWSIsn = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DDBIdentification = table.Column<int>(type: "int", nullable: false),
                    UnitCode = table.Column<int>(type: "int", nullable: true),
                    CUSTIsn = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    CCPXIsn = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    CshrIsn = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    STOREIsn = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    GATEIsn = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    UserId = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    SYSWSIdentificationNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SYSWSArabicName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SYSWSInstallationPlace = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    SYSWSPurpose = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SYSWSWorkTypeCode = table.Column<short>(type: "smallint", nullable: false),
                    Rsc = table.Column<short>(type: "smallint", nullable: true),
                    OLD_DCRTNIsn = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DCRTNIsn = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    WRHSEIsn = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    CDIsn = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    WTSTIsn = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemWorkstations", x => x.SYSWSIsn);
                });

            migrationBuilder.CreateTable(
                name: "ComputerUser",
                columns: table => new
                {
                    UserId = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMPID = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    DDBIdentification = table.Column<int>(type: "int", nullable: true),
                    CDLRIsn = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    SYSWSIsn = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    UserPasswordTypeCode = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    UserPasswordEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserEventsLoggingFlag = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    UserEventsLoggingBeginDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserEventsLoggingEndDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserLastLoginDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserLastLogoutDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRemarks = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    UserWorkStValidateFlag = table.Column<short>(type: "smallint", nullable: true),
                    Rsc = table.Column<short>(type: "smallint", nullable: true),
                    UserPasswordEncrypted = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    GEMPIsn = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    GEMPDDBIdentification = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerUser", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_ComputerUser_SystemWorkstations_SYSWSIsn",
                        column: x => x.SYSWSIsn,
                        principalTable: "SystemWorkstations",
                        principalColumn: "SYSWSIsn");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComputerUser_SYSWSIsn",
                table: "ComputerUser",
                column: "SYSWSIsn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputerUser");

            migrationBuilder.DropTable(
                name: "SystemWorkstations");
        }
    }
}
