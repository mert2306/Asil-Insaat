using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asil_Insaat.Data.Migrations
{
    public partial class v23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Yazis",
                keyColumn: "Id",
                keyValue: new Guid("54f73d71-ac36-485b-ae38-3d4746e4b47b"));

            migrationBuilder.DeleteData(
                table: "Yazis",
                keyColumn: "Id",
                keyValue: new Guid("f0fa93f7-d441-4c97-9a40-5224edb8f592"));

            migrationBuilder.UpdateData(
                table: "Kategoris",
                keyColumn: "Id",
                keyValue: new Guid("9f8cad02-c349-423e-b688-688cda3f65f8"),
                column: "OlusturulmaTarihi",
                value: new DateTime(2024, 2, 29, 13, 55, 44, 920, DateTimeKind.Local).AddTicks(6235));

            migrationBuilder.UpdateData(
                table: "Kategoris",
                keyColumn: "Id",
                keyValue: new Guid("b8a1c719-2d28-403b-b503-54497205ed6b"),
                column: "OlusturulmaTarihi",
                value: new DateTime(2024, 2, 29, 13, 55, 44, 920, DateTimeKind.Local).AddTicks(6240));

            migrationBuilder.UpdateData(
                table: "Resims",
                keyColumn: "Id",
                keyValue: new Guid("77e2d3f6-b7bf-4549-b7e2-7673d57586d6"),
                column: "OlusturulmaTarihi",
                value: new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Resims",
                keyColumn: "Id",
                keyValue: new Guid("c70801ca-cc45-4079-83c6-b0da466bbabb"),
                column: "OlusturulmaTarihi",
                value: new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("258ca24d-5f16-44a0-afcc-8dea4d026528"),
                column: "ConcurrencyStamp",
                value: "387f9abe-160c-4bb3-b36f-53531102d19d");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bb50035e-53df-4510-84a0-1b52a5695df5"),
                column: "ConcurrencyStamp",
                value: "0c510fa1-147e-4601-84d4-b1c345c5e286");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("83314624-c7a0-4468-a6aa-1f2af06f4660"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c15750cb-6fbe-4ea3-9a3c-c2b39afabf84", "AQAAAAEAACcQAAAAECmgaLLPdBSXL1ODvRQcAcWOvX3lTjKFk8j1an44zuQu2HZJ46epu0LQLG66e6Jl7g==", "490edda7-ddd3-46c8-9d79-c4ee49ba7f30" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bef76420-d441-4820-a5c0-5b39d62a8e0b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40f1b26d-3672-49de-8b6b-7da8d7a0e3d5", "AQAAAAEAACcQAAAAEL9pldr5bnWHR9P7WowbCIFHpyjq7+iuKfAMroK+DlmbF+nZ+epznr2aK9D+z37mSA==", "70173239-fb6d-4304-a352-52e7e7acc288" });

            migrationBuilder.InsertData(
                table: "Yazis",
                columns: new[] { "Id", "Baslik", "DüzenlemeTarihi", "Düzenleyen", "Icerik", "KategoriId", "OlusturulmaTarihi", "Oluşturan", "ResimId", "Silen", "SilinmisMi", "SilmeTarihi", "UserId" },
                values: new object[,]
                {
                    { new Guid("409ce59f-2b79-4407-b0f4-ad66c4128b02"), "Mertcan", null, null, "Mertcan Deneme Makalesi Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("9f8cad02-c349-423e-b688-688cda3f65f8"), new DateTime(2024, 2, 29, 13, 55, 44, 939, DateTimeKind.Local).AddTicks(3453), "Mertcan Asil", new Guid("c70801ca-cc45-4079-83c6-b0da466bbabb"), null, false, null, new Guid("83314624-c7a0-4468-a6aa-1f2af06f4660") },
                    { new Guid("49383f65-84ac-4ef8-8d53-e752daffd651"), "Mertcan", null, null, "Mertcan Deneme Makalesi Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("b8a1c719-2d28-403b-b503-54497205ed6b"), new DateTime(2024, 2, 29, 13, 55, 44, 939, DateTimeKind.Local).AddTicks(3462), "Vahit asil", new Guid("77e2d3f6-b7bf-4549-b7e2-7673d57586d6"), null, false, null, new Guid("bef76420-d441-4820-a5c0-5b39d62a8e0b") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Yazis",
                keyColumn: "Id",
                keyValue: new Guid("409ce59f-2b79-4407-b0f4-ad66c4128b02"));

            migrationBuilder.DeleteData(
                table: "Yazis",
                keyColumn: "Id",
                keyValue: new Guid("49383f65-84ac-4ef8-8d53-e752daffd651"));

            migrationBuilder.UpdateData(
                table: "Kategoris",
                keyColumn: "Id",
                keyValue: new Guid("9f8cad02-c349-423e-b688-688cda3f65f8"),
                column: "OlusturulmaTarihi",
                value: new DateTime(2024, 2, 12, 20, 0, 39, 5, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Kategoris",
                keyColumn: "Id",
                keyValue: new Guid("b8a1c719-2d28-403b-b503-54497205ed6b"),
                column: "OlusturulmaTarihi",
                value: new DateTime(2024, 2, 12, 20, 0, 39, 5, DateTimeKind.Local).AddTicks(4319));

            migrationBuilder.UpdateData(
                table: "Resims",
                keyColumn: "Id",
                keyValue: new Guid("77e2d3f6-b7bf-4549-b7e2-7673d57586d6"),
                column: "OlusturulmaTarihi",
                value: new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Resims",
                keyColumn: "Id",
                keyValue: new Guid("c70801ca-cc45-4079-83c6-b0da466bbabb"),
                column: "OlusturulmaTarihi",
                value: new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("258ca24d-5f16-44a0-afcc-8dea4d026528"),
                column: "ConcurrencyStamp",
                value: "6bee0375-d660-4f14-9120-51e4649b1717");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bb50035e-53df-4510-84a0-1b52a5695df5"),
                column: "ConcurrencyStamp",
                value: "f8a73136-f280-47fe-ba91-8dfed744187e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("83314624-c7a0-4468-a6aa-1f2af06f4660"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c003d57-87c4-4615-9fe2-9b878d724eac", "AQAAAAEAACcQAAAAEGMim288nH+/l4GnK2uc7j2X000zuoa+HJoKL8PK3DEIj0BMGpATS/hbxVWdMoQnYg==", "88d18e19-5446-499d-acb0-9ec912aa5b05" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bef76420-d441-4820-a5c0-5b39d62a8e0b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cb604ff-daee-4788-ad81-c62d246cc51e", "AQAAAAEAACcQAAAAEGKDSwLEl7IESk53mjvAeTAHzWTZcDa/n8VfmzTcNivOuj0ED13t/m1jpdbj7JwjkQ==", "753fb062-781a-4cef-8256-7136eb1e15ae" });

            migrationBuilder.InsertData(
                table: "Yazis",
                columns: new[] { "Id", "Baslik", "DüzenlemeTarihi", "Düzenleyen", "Icerik", "KategoriId", "OlusturulmaTarihi", "Oluşturan", "ResimId", "Silen", "SilinmisMi", "SilmeTarihi", "UserId" },
                values: new object[,]
                {
                    { new Guid("54f73d71-ac36-485b-ae38-3d4746e4b47b"), "Mertcan", null, null, "Mertcan Deneme Makalesi Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("b8a1c719-2d28-403b-b503-54497205ed6b"), new DateTime(2024, 2, 12, 20, 0, 39, 11, DateTimeKind.Local).AddTicks(7597), "Vahit asil", new Guid("77e2d3f6-b7bf-4549-b7e2-7673d57586d6"), null, false, null, new Guid("bef76420-d441-4820-a5c0-5b39d62a8e0b") },
                    { new Guid("f0fa93f7-d441-4c97-9a40-5224edb8f592"), "Mertcan", null, null, "Mertcan Deneme Makalesi Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("9f8cad02-c349-423e-b688-688cda3f65f8"), new DateTime(2024, 2, 12, 20, 0, 39, 11, DateTimeKind.Local).AddTicks(7572), "Mertcan Asil", new Guid("c70801ca-cc45-4079-83c6-b0da466bbabb"), null, false, null, new Guid("83314624-c7a0-4468-a6aa-1f2af06f4660") }
                });
        }
    }
}
