using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DDD_Data.Migrations
{
    public partial class Uf_City_PostalCode_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3e34bb5c-30a2-4353-a0da-f5fc5af372f0"));

            migrationBuilder.CreateTable(
                name: "Uf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FederatedUnit = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uf", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IbgeCode = table.Column<int>(type: "int", nullable: false),
                    UfId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Uf_UfId",
                        column: x => x.UfId,
                        principalTable: "Uf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostalCode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PostalCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StreetNumber = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostalCode_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Uf",
                columns: new[] { "Id", "CreatedAt", "FederatedUnit", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3293), "AC", "Acre", null },
                    { new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3357), "SP", "São Paulo", null },
                    { new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3355), "SE", "Sergipe", null },
                    { new Guid("b81f95e0-f226-4afd-9763-290001637ed4"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3352), "SC", "Santa Catarina", null },
                    { new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3350), "RS", "Rio Grande do Sul", null },
                    { new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3348), "RR", "Roraima", null },
                    { new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3345), "RO", "Rondônia", null },
                    { new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3343), "RN", "Rio Grande do Norte", null },
                    { new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3341), "RJ", "Rio de Janeiro", null },
                    { new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3339), "PR", "Paraná", null },
                    { new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3336), "PI", "Piauí", null },
                    { new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3334), "PE", "Pernambuco", null },
                    { new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3332), "PB", "Paraíba", null },
                    { new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3330), "PA", "Pará", null },
                    { new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3327), "MT", "Mato Grosso", null },
                    { new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3325), "MS", "Mato Grosso do Sul", null },
                    { new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3323), "MG", "Minas Gerais", null },
                    { new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3320), "MA", "Maranhão", null },
                    { new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3318), "GO", "Goiás", null },
                    { new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3316), "ES", "Espírito Santo", null },
                    { new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3313), "DF", "Distrito Federal", null },
                    { new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3311), "CE", "Ceará", null },
                    { new Guid("5abca453-d035-4766-a81b-9f73d683a54b"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3309), "BA", "Bahia", null },
                    { new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3307), "AP", "Amapá", null },
                    { new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3304), "AM", "Amazonas", null },
                    { new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3301), "AL", "Alagoas", null },
                    { new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"), new DateTime(2021, 9, 14, 15, 31, 33, 968, DateTimeKind.Utc).AddTicks(3360), "TO", "Tocantins", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "UpdatedAt" },
                values: new object[] { new Guid("60f7f1c1-81bd-44eb-90f3-6dd7a70f9a3d"), new DateTime(2021, 9, 14, 15, 31, 33, 965, DateTimeKind.Utc).AddTicks(9926), "admin@mail.com", "Admin", new DateTime(2021, 9, 14, 15, 31, 33, 966, DateTimeKind.Utc).AddTicks(1415) });

            migrationBuilder.CreateIndex(
                name: "IX_City_IbgeCode",
                table: "City",
                column: "IbgeCode");

            migrationBuilder.CreateIndex(
                name: "IX_City_UfId",
                table: "City",
                column: "UfId");

            migrationBuilder.CreateIndex(
                name: "IX_PostalCode_CityId",
                table: "PostalCode",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PostalCode_PostalCode",
                table: "PostalCode",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_Uf_FederatedUnit",
                table: "Uf",
                column: "FederatedUnit",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostalCode");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Uf");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("60f7f1c1-81bd-44eb-90f3-6dd7a70f9a3d"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "UpdatedAt" },
                values: new object[] { new Guid("3e34bb5c-30a2-4353-a0da-f5fc5af372f0"), new DateTime(2021, 9, 9, 16, 50, 24, 683, DateTimeKind.Utc).AddTicks(7315), "admin@mail.com", "Admin", new DateTime(2021, 9, 9, 16, 50, 24, 683, DateTimeKind.Utc).AddTicks(8336) });
        }
    }
}
