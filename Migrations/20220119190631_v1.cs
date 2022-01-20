using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProjDarko.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filmoteka",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmoteka", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Mesec",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesec", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zanr",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zanr", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistarskiBroj = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FilmotekaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Korisnik_Filmoteka_FilmotekaID",
                        column: x => x.FilmotekaID,
                        principalTable: "Filmoteka",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sifra = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FilmotekaID = table.Column<int>(type: "int", nullable: true),
                    ZanrID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Film_Filmoteka_FilmotekaID",
                        column: x => x.FilmotekaID,
                        principalTable: "Filmoteka",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Film_Zanr_ZanrID",
                        column: x => x.ZanrID,
                        principalTable: "Zanr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Iznajmljivanje",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: true),
                    FilmID = table.Column<int>(type: "int", nullable: true),
                    MesecID = table.Column<int>(type: "int", nullable: true),
                    FilmotekaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iznajmljivanje", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Iznajmljivanje_Film_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Iznajmljivanje_Filmoteka_FilmotekaID",
                        column: x => x.FilmotekaID,
                        principalTable: "Filmoteka",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Iznajmljivanje_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Iznajmljivanje_Mesec_MesecID",
                        column: x => x.MesecID,
                        principalTable: "Mesec",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Film_FilmotekaID",
                table: "Film",
                column: "FilmotekaID");

            migrationBuilder.CreateIndex(
                name: "IX_Film_ZanrID",
                table: "Film",
                column: "ZanrID");

            migrationBuilder.CreateIndex(
                name: "IX_Iznajmljivanje_FilmID",
                table: "Iznajmljivanje",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_Iznajmljivanje_FilmotekaID",
                table: "Iznajmljivanje",
                column: "FilmotekaID");

            migrationBuilder.CreateIndex(
                name: "IX_Iznajmljivanje_KorisnikID",
                table: "Iznajmljivanje",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Iznajmljivanje_MesecID",
                table: "Iznajmljivanje",
                column: "MesecID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_FilmotekaID",
                table: "Korisnik",
                column: "FilmotekaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Iznajmljivanje");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Mesec");

            migrationBuilder.DropTable(
                name: "Zanr");

            migrationBuilder.DropTable(
                name: "Filmoteka");
        }
    }
}
