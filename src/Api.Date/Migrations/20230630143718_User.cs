using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Date.Migrations
{
    /// <inheritdoc />
    public partial class User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Uf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Sigla = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameUf = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uf", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodIBGE = table.Column<int>(type: "int", nullable: false),
                    UfId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipio_Uf_UfId",
                        column: x => x.UfId,
                        principalTable: "Uf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Cep = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Logradouro = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MunicipioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cep_Municipio_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Uf",
                columns: new[] { "Id", "CreatAt", "NameUf", "Sigla", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3460), "Paraíba", "PB", null },
                    { new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3466), "Paraná", "PR", null },
                    { new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3435), "Acre", "AC", null },
                    { new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3452), "Minas Gerais", "MG", null },
                    { new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3455), "Mato Grosso", "MT", null },
                    { new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3454), "Mato Grosso do Sul", "MS", null },
                    { new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3441), "Amapá", "AP", null },
                    { new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3469), "Rio de Janeiro", "RJ", null },
                    { new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3471), "Rio Grande do Norte", "RN", null },
                    { new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3451), "Maranhão", "MA", null },
                    { new Guid("5abca453-d035-4766-a81b-9f73d683a54b"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3443), "Bahia", "BA", null },
                    { new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3444), "Ceará", "CE", null },
                    { new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3438), "Alagoas", "AL", null },
                    { new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3449), "Goiás", "GO", null },
                    { new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3458), "Pará", "PA", null },
                    { new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3476), "Rio Grande do Sul", "RS", null },
                    { new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3472), "Rondônia", "RO", null },
                    { new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3484), "Tocantins", "TO", null },
                    { new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3474), "Roraima", "RR", null },
                    { new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3462), "Pernambuco", "PE", null },
                    { new Guid("b81f95e0-f226-4afd-9763-290001637ed4"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3477), "Santa Catarina", "SC", null },
                    { new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3446), "Distrito Federal", "DF", null },
                    { new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3447), "Espírito Santo", "ES", null },
                    { new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3440), "Amazonas", "AM", null },
                    { new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3482), "São Paulo", "SP", null },
                    { new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3463), "Piauí", "PI", null },
                    { new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"), new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3480), "Sergipe", "SE", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("6d1daeb5-13e3-49bf-b2ec-72175ec41276"), new DateTime(2023, 6, 30, 11, 37, 17, 986, DateTimeKind.Local).AddTicks(3267), "adm@mail.com", "Administrador", new DateTime(2023, 6, 30, 11, 37, 17, 986, DateTimeKind.Local).AddTicks(3283) });

            migrationBuilder.CreateIndex(
                name: "IX_Cep_Cep",
                table: "Cep",
                column: "Cep");

            migrationBuilder.CreateIndex(
                name: "IX_Cep_MunicipioId",
                table: "Cep",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_CodIBGE",
                table: "Municipio",
                column: "CodIBGE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_UfId",
                table: "Municipio",
                column: "UfId");

            migrationBuilder.CreateIndex(
                name: "IX_Uf_Sigla",
                table: "Uf",
                column: "Sigla",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cep");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropTable(
                name: "Uf");
        }
    }
}
