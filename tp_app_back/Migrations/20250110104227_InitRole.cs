using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tp_app_back.Migrations
{
    /// <inheritdoc />
    public partial class InitRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("32a792b9-9e3e-4aaa-995e-07f881e9cb01"), "User" },
                    { new Guid("486a2041-b6e9-4dc0-9d85-d141bed9c9b8"), "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("32a792b9-9e3e-4aaa-995e-07f881e9cb01"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("486a2041-b6e9-4dc0-9d85-d141bed9c9b8"));
        }
    }
}
