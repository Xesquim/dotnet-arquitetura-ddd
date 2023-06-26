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
                values: new object[] { new Guid("cf93d96c-dc91-4e33-9c34-63a8349d1def"), new DateTime(2023, 6, 26, 0, 51, 39, 966, DateTimeKind.Local).AddTicks(2008), "admin@test.com", "$2a$11$Fi.g6aTNlZyh.6.n05PDM.Jj62cmm10ANhPe.3I9r/r.kM8HqNzKS", new DateTime(2023, 6, 26, 0, 51, 39, 967, DateTimeKind.Local).AddTicks(2621), "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: new Guid("cf93d96c-dc91-4e33-9c34-63a8349d1def"));
        }
    }
}
