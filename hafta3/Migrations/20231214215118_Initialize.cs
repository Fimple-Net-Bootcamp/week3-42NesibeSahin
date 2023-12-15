using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hafta3.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Adi = table.Column<string>(type: "TEXT", nullable: false),
                    Soyadi = table.Column<string>(type: "TEXT", nullable: false),
                    TC = table.Column<string>(type: "TEXT", nullable: false),
                    isSilindi = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EvcilHayvanlar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Isim = table.Column<string>(type: "TEXT", nullable: false),
                    Kodu = table.Column<int>(type: "INTEGER", nullable: false),
                    Tur = table.Column<string>(type: "TEXT", nullable: false),
                    KullaniciID = table.Column<int>(type: "INTEGER", nullable: false),
                    isSilindi = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvcilHayvanlar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EvcilHayvanlar_Kullanicilar_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aktiviteler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Adi = table.Column<string>(type: "TEXT", nullable: false),
                    EvcilHayvanID = table.Column<int>(type: "INTEGER", nullable: false),
                    isSilindi = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktiviteler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Aktiviteler_EvcilHayvanlar_EvcilHayvanID",
                        column: x => x.EvcilHayvanID,
                        principalTable: "EvcilHayvanlar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Besinler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Adi = table.Column<string>(type: "TEXT", nullable: false),
                    EvcilHayvanID = table.Column<int>(type: "INTEGER", nullable: false),
                    isSilindi = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Besinler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Besinler_EvcilHayvanlar_EvcilHayvanID",
                        column: x => x.EvcilHayvanID,
                        principalTable: "EvcilHayvanlar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaglikDurumlari",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DurumAdi = table.Column<string>(type: "TEXT", nullable: false),
                    Tarih = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HastaMi = table.Column<bool>(type: "INTEGER", nullable: false),
                    EvcilHayvanID = table.Column<int>(type: "INTEGER", nullable: false),
                    isSilindi = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaglikDurumlari", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SaglikDurumlari_EvcilHayvanlar_EvcilHayvanID",
                        column: x => x.EvcilHayvanID,
                        principalTable: "EvcilHayvanlar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aktiviteler_EvcilHayvanID",
                table: "Aktiviteler",
                column: "EvcilHayvanID");

            migrationBuilder.CreateIndex(
                name: "IX_Besinler_EvcilHayvanID",
                table: "Besinler",
                column: "EvcilHayvanID");

            migrationBuilder.CreateIndex(
                name: "IX_EvcilHayvanlar_KullaniciID",
                table: "EvcilHayvanlar",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_SaglikDurumlari_EvcilHayvanID",
                table: "SaglikDurumlari",
                column: "EvcilHayvanID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aktiviteler");

            migrationBuilder.DropTable(
                name: "Besinler");

            migrationBuilder.DropTable(
                name: "SaglikDurumlari");

            migrationBuilder.DropTable(
                name: "EvcilHayvanlar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");
        }
    }
}
