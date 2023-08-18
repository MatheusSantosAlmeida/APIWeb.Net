using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Date.Migrations
{
    /// <inheritdoc />
    public partial class Uf_Municipio_Cep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6d1daeb5-13e3-49bf-b2ec-72175ec41276"));

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Cep",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6025));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6031));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(5997));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6014));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6021));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6003));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6032));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6034));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("5abca453-d035-4766-a81b-9f73d683a54b"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6005));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6006));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6000));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6041));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6036));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6039));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6027));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("b81f95e0-f226-4afd-9763-290001637ed4"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6043));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6008));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6001));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6047));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6028));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 15, 7, 6, 445, DateTimeKind.Utc).AddTicks(6044));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("868b86b0-c623-4f31-ab76-284bbbb85644"), new DateTime(2023, 6, 30, 12, 7, 6, 445, DateTimeKind.Local).AddTicks(5839), "adm@mail.com", "Administrador", new DateTime(2023, 6, 30, 12, 7, 6, 445, DateTimeKind.Local).AddTicks(5856) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("868b86b0-c623-4f31-ab76-284bbbb85644"));

            migrationBuilder.UpdateData(
                table: "Cep",
                keyColumn: "Numero",
                keyValue: null,
                column: "Numero",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Cep",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3460));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3466));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3452));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3455));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3454));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3441));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3469));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3471));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3451));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("5abca453-d035-4766-a81b-9f73d683a54b"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3443));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3444));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3438));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3449));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3458));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3476));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3472));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3484));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3474));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3462));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("b81f95e0-f226-4afd-9763-290001637ed4"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3477));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3446));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3447));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3440));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3482));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3463));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"),
                column: "CreatAt",
                value: new DateTime(2023, 6, 30, 14, 37, 17, 986, DateTimeKind.Utc).AddTicks(3480));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("6d1daeb5-13e3-49bf-b2ec-72175ec41276"), new DateTime(2023, 6, 30, 11, 37, 17, 986, DateTimeKind.Local).AddTicks(3267), "adm@mail.com", "Administrador", new DateTime(2023, 6, 30, 11, 37, 17, 986, DateTimeKind.Local).AddTicks(3283) });
        }
    }
}
