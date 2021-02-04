using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atom.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 2, 4, 19, 32, 24, 521, DateTimeKind.Local).AddTicks(2515)),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Balance", "CreationDate", "Currency" },
                values: new object[,]
                {
                    { 1L, 500m, new DateTime(2021, 2, 4, 19, 32, 24, 533, DateTimeKind.Local).AddTicks(9698), "$" },
                    { 2L, 1500m, new DateTime(2021, 2, 4, 19, 32, 24, 534, DateTimeKind.Local).AddTicks(693), "$" },
                    { 3L, 100m, new DateTime(2021, 2, 4, 19, 32, 24, 534, DateTimeKind.Local).AddTicks(699), "$" },
                    { 4L, 45m, new DateTime(2021, 2, 4, 19, 32, 24, 534, DateTimeKind.Local).AddTicks(701), "$" },
                    { 5L, 50m, new DateTime(2021, 2, 4, 19, 32, 24, 534, DateTimeKind.Local).AddTicks(703), "$" },
                    { 7L, 900m, new DateTime(2021, 2, 4, 19, 32, 24, 534, DateTimeKind.Local).AddTicks(707), "$" },
                    { 8L, 90m, new DateTime(2021, 2, 4, 19, 32, 24, 534, DateTimeKind.Local).AddTicks(709), "$" },
                    { 9L, 19m, new DateTime(2021, 2, 4, 19, 32, 24, 534, DateTimeKind.Local).AddTicks(710), "$" },
                    { 10L, 190m, new DateTime(2021, 2, 4, 19, 32, 24, 534, DateTimeKind.Local).AddTicks(712), "$" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
