using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KategoriAciklamasi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Masalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasaAd = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Locked = table.Column<bool>(type: "bit", nullable: true),
                    MasaAciklama = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OdemeSekiller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdemeSekilAd = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdemeSekiller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiparisSekiller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisSekilAd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisSekiller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Soyadi = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TelNoSu = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Adresi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Epostasi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Locked = table.Column<bool>(type: "bit", nullable: false),
                    Createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UrunFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UrunAdet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urunler_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siparisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriID = table.Column<int>(type: "int", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    OdemeSekilId = table.Column<int>(type: "int", nullable: true),
                    SiparisSekilId = table.Column<int>(type: "int", nullable: true),
                    MasaId = table.Column<int>(type: "int", nullable: true),
                    SiparisVerenAd = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    SiparisVerenSoyad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SiparisAdres = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SiparisTelNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndririmTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ToplamTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SiparisZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SiparisAciklama = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Siparisler_Masalar_MasaId",
                        column: x => x.MasaId,
                        principalTable: "Masalar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Siparisler_OdemeSekiller_OdemeSekilId",
                        column: x => x.OdemeSekilId,
                        principalTable: "OdemeSekiller",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Siparisler_SiparisSekiller_SiparisSekilId",
                        column: x => x.SiparisSekilId,
                        principalTable: "SiparisSekiller",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SiparisUrun",
                columns: table => new
                {
                    SiparislerId = table.Column<int>(type: "int", nullable: false),
                    UrunlerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisUrun", x => new { x.SiparislerId, x.UrunlerId });
                    table.ForeignKey(
                        name: "FK_SiparisUrun_Siparisler_SiparislerId",
                        column: x => x.SiparislerId,
                        principalTable: "Siparisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiparisUrun_Urunler_UrunlerId",
                        column: x => x.UrunlerId,
                        principalTable: "Urunler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_MasaId",
                table: "Siparisler",
                column: "MasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_OdemeSekilId",
                table: "Siparisler",
                column: "OdemeSekilId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_SiparisSekilId",
                table: "Siparisler",
                column: "SiparisSekilId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisUrun_UrunlerId",
                table: "SiparisUrun",
                column: "UrunlerId");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_KategoriId",
                table: "Urunler",
                column: "KategoriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiparisUrun");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Masalar");

            migrationBuilder.DropTable(
                name: "OdemeSekiller");

            migrationBuilder.DropTable(
                name: "SiparisSekiller");

            migrationBuilder.DropTable(
                name: "Kategoriler");
        }
    }
}
