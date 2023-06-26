using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _0002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "create_at", "email", "password", "update_at", "user_name" },
                values: new object[] { new Guid("ce83f349-7e85-477c-8c12-6dddd58704ea"), new DateTime(2023, 6, 26, 0, 23, 48, 986, DateTimeKind.Local).AddTicks(9262), "admin@test.com", "password", new DateTime(2023, 6, 26, 0, 23, 48, 987, DateTimeKind.Local).AddTicks(8333), "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: new Guid("ce83f349-7e85-477c-8c12-6dddd58704ea"));
        }
    }
}
