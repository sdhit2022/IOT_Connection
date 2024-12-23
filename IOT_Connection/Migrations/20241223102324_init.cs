using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOT_Connection.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceHdrs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Icon = table.Column<int>(type: "int", nullable: true),
                    SystemCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UniqId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceHdrs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    ActiveCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceDtls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FkDeviceHdrId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceDtls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceDtls_DeviceHdrs_FkDeviceHdrId",
                        column: x => x.FkDeviceHdrId,
                        principalTable: "DeviceHdrs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RelUserAndDevices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FkDeviceHdrId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelUserAndDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelUserAndDevices_DeviceHdrs_FkDeviceHdrId",
                        column: x => x.FkDeviceHdrId,
                        principalTable: "DeviceHdrs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RelUserAndDevices_Users_FkUserId",
                        column: x => x.FkUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDtls_FkDeviceHdrId",
                table: "DeviceDtls",
                column: "FkDeviceHdrId");

            migrationBuilder.CreateIndex(
                name: "IX_RelUserAndDevices_FkDeviceHdrId",
                table: "RelUserAndDevices",
                column: "FkDeviceHdrId");

            migrationBuilder.CreateIndex(
                name: "IX_RelUserAndDevices_FkUserId",
                table: "RelUserAndDevices",
                column: "FkUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceDtls");

            migrationBuilder.DropTable(
                name: "RelUserAndDevices");

            migrationBuilder.DropTable(
                name: "DeviceHdrs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
