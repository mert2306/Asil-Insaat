using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asil_Insaat.Data.Migrations
{
    public partial class versiyon1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoris",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oluşturan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Düzenleyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DüzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Silen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilinmisMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoris", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oluşturan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Düzenleyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DüzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Silen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilinmisMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyisim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Resims_ResimId",
                        column: x => x.ResimId,
                        principalTable: "Resims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yazis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResimId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Oluşturan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Düzenleyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DüzenlemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Silen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilinmisMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yazis_Kategoris_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Yazis_Resims_ResimId",
                        column: x => x.ResimId,
                        principalTable: "Resims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Yazis_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategoris",
                columns: new[] { "Id", "DüzenlemeTarihi", "Düzenleyen", "Isim", "OlusturulmaTarihi", "Oluşturan", "Silen", "SilinmisMi", "SilmeTarihi" },
                values: new object[,]
                {
                    { new Guid("9f8cad02-c349-423e-b688-688cda3f65f8"), null, null, "Birinci", new DateTime(2024, 2, 12, 20, 0, 39, 5, DateTimeKind.Local).AddTicks(4313), "Mertcan Asil", null, false, null },
                    { new Guid("b8a1c719-2d28-403b-b503-54497205ed6b"), null, null, "Ikinci", new DateTime(2024, 2, 12, 20, 0, 39, 5, DateTimeKind.Local).AddTicks(4319), "Vahit Asil", null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Resims",
                columns: new[] { "Id", "DüzenlemeTarihi", "Düzenleyen", "FileName", "FileType", "OlusturulmaTarihi", "Oluşturan", "Silen", "SilinmisMi", "SilmeTarihi" },
                values: new object[,]
                {
                    { new Guid("77e2d3f6-b7bf-4549-b7e2-7673d57586d6"), null, null, "Images/AsiltestImages", "png", new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Local), "Vahit asil", null, false, null },
                    { new Guid("c70801ca-cc45-4079-83c6-b0da466bbabb"), null, null, "Images/testImages", "jpg", new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Local), "Mertcan asil", null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("258ca24d-5f16-44a0-afcc-8dea4d026528"), "6bee0375-d660-4f14-9120-51e4649b1717", "Admin", "ADMIN" },
                    { new Guid("bb50035e-53df-4510-84a0-1b52a5695df5"), "f8a73136-f280-47fe-ba91-8dfed744187e", "Superadmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Isim", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ResimId", "SecurityStamp", "Soyisim", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("83314624-c7a0-4468-a6aa-1f2af06f4660"), 0, "1c003d57-87c4-4615-9fe2-9b878d724eac", "mertcanasil3@gmail.com", true, "Mertcan", false, null, "MERTCANASIL3@GMAIL.COM", "MERTCANASIL3@GMAIL.COM", "AQAAAAEAACcQAAAAEGMim288nH+/l4GnK2uc7j2X000zuoa+HJoKL8PK3DEIj0BMGpATS/hbxVWdMoQnYg==", null, false, new Guid("c70801ca-cc45-4079-83c6-b0da466bbabb"), "88d18e19-5446-499d-acb0-9ec912aa5b05", "Asıl", false, "mertcanasil3@gmail.com" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Isim", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ResimId", "SecurityStamp", "Soyisim", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("bef76420-d441-4820-a5c0-5b39d62a8e0b"), 0, "5cb604ff-daee-4788-ad81-c62d246cc51e", "asilinsaatyapiyalitim@gmail.com", false, "Vahit", false, null, "ASILINSAATYAPIYALITIM@GMAIL.COM", "ASILINSAATYAPIYALITIM@GMAIL.COM", "AQAAAAEAACcQAAAAEGKDSwLEl7IESk53mjvAeTAHzWTZcDa/n8VfmzTcNivOuj0ED13t/m1jpdbj7JwjkQ==", null, false, new Guid("77e2d3f6-b7bf-4549-b7e2-7673d57586d6"), "753fb062-781a-4cef-8256-7136eb1e15ae", "Asil", false, "asilinsaatyapiyalitim@gmail.com" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("bb50035e-53df-4510-84a0-1b52a5695df5"), new Guid("83314624-c7a0-4468-a6aa-1f2af06f4660") },
                    { new Guid("258ca24d-5f16-44a0-afcc-8dea4d026528"), new Guid("bef76420-d441-4820-a5c0-5b39d62a8e0b") }
                });

            migrationBuilder.InsertData(
                table: "Yazis",
                columns: new[] { "Id", "Baslik", "DüzenlemeTarihi", "Düzenleyen", "Icerik", "KategoriId", "OlusturulmaTarihi", "Oluşturan", "ResimId", "Silen", "SilinmisMi", "SilmeTarihi", "UserId" },
                values: new object[,]
                {
                    { new Guid("54f73d71-ac36-485b-ae38-3d4746e4b47b"), "Mertcan", null, null, "Mertcan Deneme Makalesi Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("b8a1c719-2d28-403b-b503-54497205ed6b"), new DateTime(2024, 2, 12, 20, 0, 39, 11, DateTimeKind.Local).AddTicks(7597), "Vahit asil", new Guid("77e2d3f6-b7bf-4549-b7e2-7673d57586d6"), null, false, null, new Guid("bef76420-d441-4820-a5c0-5b39d62a8e0b") },
                    { new Guid("f0fa93f7-d441-4c97-9a40-5224edb8f592"), "Mertcan", null, null, "Mertcan Deneme Makalesi Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("9f8cad02-c349-423e-b688-688cda3f65f8"), new DateTime(2024, 2, 12, 20, 0, 39, 11, DateTimeKind.Local).AddTicks(7572), "Mertcan Asil", new Guid("c70801ca-cc45-4079-83c6-b0da466bbabb"), null, false, null, new Guid("83314624-c7a0-4468-a6aa-1f2af06f4660") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ResimId",
                table: "Users",
                column: "ResimId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Yazis_KategoriId",
                table: "Yazis",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Yazis_ResimId",
                table: "Yazis",
                column: "ResimId");

            migrationBuilder.CreateIndex(
                name: "IX_Yazis_UserId",
                table: "Yazis",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Yazis");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Kategoris");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Resims");
        }
    }
}
