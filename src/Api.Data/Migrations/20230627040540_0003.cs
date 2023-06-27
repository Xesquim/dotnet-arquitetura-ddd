using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _0003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: new Guid("cf93d96c-dc91-4e33-9c34-63a8349d1def"));

            migrationBuilder.CreateTable(
                name: "si",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    create_at = table.Column<DateTime>(nullable: true),
                    update_at = table.Column<DateTime>(nullable: true),
                    abbreviation = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_si_entity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    create_at = table.Column<DateTime>(nullable: true),
                    update_at = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(maxLength: 60, nullable: false),
                    ibge_code = table.Column<int>(nullable: false),
                    si_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_city_entity", x => x.id);
                    table.ForeignKey(
                        name: "fk_city_entity_si_entity_si_id",
                        column: x => x.si_id,
                        principalTable: "si",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "zip_code",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    create_at = table.Column<DateTime>(nullable: true),
                    update_at = table.Column<DateTime>(nullable: true),
                    zip_code = table.Column<string>(maxLength: 10, nullable: false),
                    street = table.Column<string>(maxLength: 60, nullable: false),
                    number = table.Column<string>(maxLength: 10, nullable: true),
                    city_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_zip_code_entity", x => x.id);
                    table.ForeignKey(
                        name: "fk_zip_code_entity_city_entity_city_id",
                        column: x => x.city_id,
                        principalTable: "city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "si",
                columns: new[] { "id", "abbreviation", "create_at", "name", "update_at" },
                values: new object[,]
                {
                    { new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"), "AC", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6899), "Acre", null },
                    { new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"), "SP", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6997), "São Paulo", null },
                    { new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"), "SE", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6995), "Sergipe", null },
                    { new Guid("b81f95e0-f226-4afd-9763-290001637ed4"), "SC", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6993), "Santa Catarina", null },
                    { new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"), "RS", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6991), "Rio Grande do Sul", null },
                    { new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"), "RR", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6990), "Roraima", null },
                    { new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"), "RO", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6988), "Rondônia", null },
                    { new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"), "RN", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6986), "Rio Grande do Norte", null },
                    { new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"), "RJ", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6984), "Rio de Janeiro", null },
                    { new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"), "PR", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6982), "Paraná", null },
                    { new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"), "PI", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6980), "Piauí", null },
                    { new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"), "PE", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6978), "Pernambuco", null },
                    { new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"), "PB", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6977), "Paraíba", null },
                    { new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"), "PA", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6975), "Pará", null },
                    { new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"), "MT", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6973), "Mato Grosso", null },
                    { new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"), "MS", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6972), "Mato Grosso do Sul", null },
                    { new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"), "MG", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6970), "Minas Gerais", null },
                    { new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"), "MA", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6968), "Maranhão", null },
                    { new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"), "GO", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6966), "Goiás", null },
                    { new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"), "ES", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6964), "Espírito Santo", null },
                    { new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"), "DF", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6962), "Distrito Federal", null },
                    { new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"), "CE", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6960), "Ceará", null },
                    { new Guid("5abca453-d035-4766-a81b-9f73d683a54b"), "BA", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6958), "Bahia", null },
                    { new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"), "AP", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6956), "Amapá", null },
                    { new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"), "AM", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6953), "Amazonas", null },
                    { new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"), "AL", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6950), "Alagoas", null },
                    { new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"), "TO", new DateTime(2023, 6, 27, 4, 5, 40, 72, DateTimeKind.Utc).AddTicks(6999), "Tocantins", null }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "create_at", "email", "password", "update_at", "user_name" },
                values: new object[] { new Guid("444f5399-3051-44fd-a5b9-255b84a4eb3d"), new DateTime(2023, 6, 27, 1, 5, 39, 949, DateTimeKind.Local).AddTicks(203), "admin@test.com", "$2a$11$3w8lcGkBoiMT2wUn7V2G.uzKLuuNcKQON4WP.N5BoZQ5Tzu1sA7XO", new DateTime(2023, 6, 27, 1, 5, 39, 949, DateTimeKind.Local).AddTicks(9888), "admin" });

            migrationBuilder.CreateIndex(
                name: "ix_city_ibge_code",
                table: "city",
                column: "ibge_code");

            migrationBuilder.CreateIndex(
                name: "ix_city_entity_si_id",
                table: "city",
                column: "si_id");

            migrationBuilder.CreateIndex(
                name: "ix_si_abbreviation",
                table: "si",
                column: "abbreviation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_zip_code_entity_city_id",
                table: "zip_code",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "ix_zip_code_zip_code",
                table: "zip_code",
                column: "zip_code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "zip_code");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "si");

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: new Guid("444f5399-3051-44fd-a5b9-255b84a4eb3d"));

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "create_at", "email", "password", "update_at", "user_name" },
                values: new object[] { new Guid("cf93d96c-dc91-4e33-9c34-63a8349d1def"), new DateTime(2023, 6, 26, 0, 51, 39, 966, DateTimeKind.Local).AddTicks(2008), "admin@test.com", "$2a$11$Fi.g6aTNlZyh.6.n05PDM.Jj62cmm10ANhPe.3I9r/r.kM8HqNzKS", new DateTime(2023, 6, 26, 0, 51, 39, 967, DateTimeKind.Local).AddTicks(2621), "admin" });
        }
    }
}
