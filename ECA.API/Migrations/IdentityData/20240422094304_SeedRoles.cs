using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECA.API.Migrations.IdentityData
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "Manager", "Passenger-Manager".ToUpper(), Guid.NewGuid().ToString() });
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "Employee", "Passenger-Employee".ToUpper(), Guid.NewGuid().ToString() });
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] {"Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "Customer", "Passenger-Customer".ToUpper(), Guid.NewGuid().ToString() });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
