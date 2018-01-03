using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace eUniverzitet.Data.Migrations
{
    public partial class A : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AkademskaGodinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AkademskaGodinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisniks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisniks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NaucnaOblasts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaucnaOblasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regijas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regijas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketKategorijas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketKategorijas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZaposlenjeMjestos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    ZaposlenjeNacin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZaposlenjeMjestos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IspitniRoks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AkademskaGodinaId = table.Column<int>(nullable: false),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IspitniRoks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IspitniRoks_AkademskaGodinas_AkademskaGodinaId",
                        column: x => x.AkademskaGodinaId,
                        principalTable: "AkademskaGodinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifikacijas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsRead = table.Column<bool>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    Naslov = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Vrijeme = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifikacijas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifikacijas_Korisniks_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisniks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zaposleniks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KorisnikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposleniks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zaposleniks_Korisniks_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisniks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizacionaJedinicas",
                columns: table => new
                {
                    NaucnaOblastId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizacionaJedinicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizacionaJedinicas_NaucnaOblasts_NaucnaOblastId",
                        column: x => x.NaucnaOblastId,
                        principalTable: "NaucnaOblasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opstinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Opis = table.Column<string>(nullable: true),
                    RegijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opstinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opstinas_Regijas_RegijaId",
                        column: x => x.RegijaId,
                        principalTable: "Regijas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Odsjeks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FakultetId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odsjeks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odsjeks_OrganizacionaJedinicas_FakultetId",
                        column: x => x.FakultetId,
                        principalTable: "OrganizacionaJedinicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zaposlenjes",
                columns: table => new
                {
                    NastavnoOsobljeZvanje = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    KorisnickaUloga = table.Column<int>(nullable: false),
                    OrganizacionaJedinicaId = table.Column<int>(nullable: false),
                    UgovorKraj = table.Column<DateTime>(nullable: true),
                    UgovorPocetak = table.Column<DateTime>(nullable: false),
                    ZaposlenikId = table.Column<int>(nullable: false),
                    ZaposlenjeMjestoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenjes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zaposlenjes_OrganizacionaJedinicas_OrganizacionaJedinicaId",
                        column: x => x.OrganizacionaJedinicaId,
                        principalTable: "OrganizacionaJedinicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zaposlenjes_Zaposleniks_ZaposlenikId",
                        column: x => x.ZaposlenikId,
                        principalTable: "Zaposleniks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zaposlenjes_ZaposlenjeMjestos_ZaposlenjeMjestoId",
                        column: x => x.ZaposlenjeMjestoId,
                        principalTable: "ZaposlenjeMjestos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    OpstinaPrebivalistaId = table.Column<int>(nullable: true),
                    OpstinaRodjenjaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Korisniks_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisniks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Opstinas_OpstinaPrebivalistaId",
                        column: x => x.OpstinaPrebivalistaId,
                        principalTable: "Opstinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Opstinas_OpstinaRodjenjaId",
                        column: x => x.OpstinaRodjenjaId,
                        principalTable: "Opstinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NPPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AkademskaGodinaId = table.Column<int>(nullable: false),
                    FakultetId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    OdsjekId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NPPs_AkademskaGodinas_AkademskaGodinaId",
                        column: x => x.AkademskaGodinaId,
                        principalTable: "AkademskaGodinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NPPs_OrganizacionaJedinicas_FakultetId",
                        column: x => x.FakultetId,
                        principalTable: "OrganizacionaJedinicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NPPs_Odsjeks_OdsjekId",
                        column: x => x.OdsjekId,
                        principalTable: "Odsjeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Predmets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ects = table.Column<float>(nullable: false),
                    GodinaStudija = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    NppId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Predmets_NPPs_NppId",
                        column: x => x.NppId,
                        principalTable: "NPPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Studiranjes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojIndeksa = table.Column<string>(nullable: true),
                    NppId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    StudentiranjeStatus = table.Column<int>(nullable: false),
                    UgovorKraj = table.Column<DateTime>(nullable: true),
                    UgovorPocetak = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studiranjes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Studiranjes_NPPs_NppId",
                        column: x => x.NppId,
                        principalTable: "NPPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Studiranjes_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IzvodjenjePredmetas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AkademskaGodinaId = table.Column<int>(nullable: false),
                    PredmetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzvodjenjePredmetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IzvodjenjePredmetas_AkademskaGodinas_AkademskaGodinaId",
                        column: x => x.AkademskaGodinaId,
                        principalTable: "AkademskaGodinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IzvodjenjePredmetas_Predmets_PredmetId",
                        column: x => x.PredmetId,
                        principalTable: "Predmets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UpisGodines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AkademskaGodinaId = table.Column<int>(nullable: false),
                    Cijena = table.Column<float>(nullable: false),
                    Datum1_ZimskiUpis = table.Column<DateTime>(nullable: true),
                    Datum2_ZimskiOvjera = table.Column<DateTime>(nullable: true),
                    Datum3_LjetniUpis = table.Column<DateTime>(nullable: true),
                    Datum4_LjetniOvjera = table.Column<DateTime>(nullable: true),
                    GodinaStudija = table.Column<int>(nullable: false),
                    StudiranjeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpisGodines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpisGodines_AkademskaGodinas_AkademskaGodinaId",
                        column: x => x.AkademskaGodinaId,
                        principalTable: "AkademskaGodinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UpisGodines_Studiranjes_StudiranjeId",
                        column: x => x.StudiranjeId,
                        principalTable: "Studiranjes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AngaziranNaPredmets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AngaziranNaPredmetTip = table.Column<int>(nullable: false),
                    IzvodjenjePredmetaId = table.Column<int>(nullable: false),
                    NastavnoOsobljeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AngaziranNaPredmets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AngaziranNaPredmets_IzvodjenjePredmetas_IzvodjenjePredmetaId",
                        column: x => x.IzvodjenjePredmetaId,
                        principalTable: "IzvodjenjePredmetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AngaziranNaPredmets_Zaposlenjes_NastavnoOsobljeId",
                        column: x => x.NastavnoOsobljeId,
                        principalTable: "Zaposlenjes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IspitniTermins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IspitniRokId = table.Column<int>(nullable: false),
                    IzvodjenjePredmetaId = table.Column<int>(nullable: false),
                    MjestoIspita = table.Column<string>(nullable: true),
                    VrijemeIspita = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IspitniTermins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IspitniTermins_IspitniRoks_IspitniRokId",
                        column: x => x.IspitniRokId,
                        principalTable: "IspitniRoks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IspitniTermins_IzvodjenjePredmetas_IzvodjenjePredmetaId",
                        column: x => x.IzvodjenjePredmetaId,
                        principalTable: "IzvodjenjePredmetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsZatvoren = table.Column<bool>(nullable: false),
                    IzvodjenjePredmetaId = table.Column<int>(nullable: true),
                    Naslov = table.Column<string>(nullable: true),
                    StudiranjeId = table.Column<int>(nullable: false),
                    TicketKategorijaId = table.Column<int>(nullable: true),
                    ZaposlenikId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_IzvodjenjePredmetas_IzvodjenjePredmetaId",
                        column: x => x.IzvodjenjePredmetaId,
                        principalTable: "IzvodjenjePredmetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Studiranjes_StudiranjeId",
                        column: x => x.StudiranjeId,
                        principalTable: "Studiranjes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketKategorijas_TicketKategorijaId",
                        column: x => x.TicketKategorijaId,
                        principalTable: "TicketKategorijas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Zaposleniks_ZaposlenikId",
                        column: x => x.ZaposlenikId,
                        principalTable: "Zaposleniks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SlusaPredmets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumOcjene = table.Column<DateTime>(nullable: true),
                    FinalnaOcjena = table.Column<int>(nullable: true),
                    IzvodjenjePredmetaId = table.Column<int>(nullable: false),
                    Priznato = table.Column<bool>(nullable: false),
                    UpisGodineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlusaPredmets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SlusaPredmets_IzvodjenjePredmetas_IzvodjenjePredmetaId",
                        column: x => x.IzvodjenjePredmetaId,
                        principalTable: "IzvodjenjePredmetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SlusaPredmets_UpisGodines_UpisGodineId",
                        column: x => x.UpisGodineId,
                        principalTable: "UpisGodines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UplataStudijas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumUplate = table.Column<DateTime>(nullable: false),
                    EvidentiranoDatum = table.Column<DateTime>(nullable: false),
                    EvidentiranoKorisnikId = table.Column<int>(nullable: false),
                    Iznos = table.Column<float>(nullable: false),
                    Svrha = table.Column<string>(nullable: true),
                    UpisGodineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UplataStudijas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UplataStudijas_Korisniks_EvidentiranoKorisnikId",
                        column: x => x.EvidentiranoKorisnikId,
                        principalTable: "Korisniks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UplataStudijas_UpisGodines_UpisGodineId",
                        column: x => x.UpisGodineId,
                        principalTable: "UpisGodines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketPorukas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KorisnikId = table.Column<int>(nullable: false),
                    Poruka = table.Column<string>(nullable: true),
                    TicketId = table.Column<int>(nullable: false),
                    TicketId1 = table.Column<int>(nullable: true),
                    Vrijeme = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPorukas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketPorukas_Korisniks_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisniks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketPorukas_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketPorukas_Tickets_TicketId1",
                        column: x => x.TicketId1,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrijavaIspitas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IspitniTerminId = table.Column<int>(nullable: false),
                    OdjavaDatum = table.Column<DateTime>(nullable: true),
                    PrijavaDatum = table.Column<DateTime>(nullable: false),
                    SlusaPredmetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrijavaIspitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrijavaIspitas_IspitniTermins_IspitniTerminId",
                        column: x => x.IspitniTerminId,
                        principalTable: "IspitniTermins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrijavaIspitas_SlusaPredmets_SlusaPredmetId",
                        column: x => x.SlusaPredmetId,
                        principalTable: "SlusaPredmets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AngaziranNaPredmets_IzvodjenjePredmetaId",
                table: "AngaziranNaPredmets",
                column: "IzvodjenjePredmetaId");

            migrationBuilder.CreateIndex(
                name: "IX_AngaziranNaPredmets_NastavnoOsobljeId",
                table: "AngaziranNaPredmets",
                column: "NastavnoOsobljeId");

            migrationBuilder.CreateIndex(
                name: "IX_IspitniRoks_AkademskaGodinaId",
                table: "IspitniRoks",
                column: "AkademskaGodinaId");

            migrationBuilder.CreateIndex(
                name: "IX_IspitniTermins_IspitniRokId",
                table: "IspitniTermins",
                column: "IspitniRokId");

            migrationBuilder.CreateIndex(
                name: "IX_IspitniTermins_IzvodjenjePredmetaId",
                table: "IspitniTermins",
                column: "IzvodjenjePredmetaId");

            migrationBuilder.CreateIndex(
                name: "IX_IzvodjenjePredmetas_AkademskaGodinaId",
                table: "IzvodjenjePredmetas",
                column: "AkademskaGodinaId");

            migrationBuilder.CreateIndex(
                name: "IX_IzvodjenjePredmetas_PredmetId",
                table: "IzvodjenjePredmetas",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifikacijas_KorisnikId",
                table: "Notifikacijas",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_NPPs_AkademskaGodinaId",
                table: "NPPs",
                column: "AkademskaGodinaId");

            migrationBuilder.CreateIndex(
                name: "IX_NPPs_FakultetId",
                table: "NPPs",
                column: "FakultetId");

            migrationBuilder.CreateIndex(
                name: "IX_NPPs_OdsjekId",
                table: "NPPs",
                column: "OdsjekId");

            migrationBuilder.CreateIndex(
                name: "IX_Odsjeks_FakultetId",
                table: "Odsjeks",
                column: "FakultetId");

            migrationBuilder.CreateIndex(
                name: "IX_Opstinas_RegijaId",
                table: "Opstinas",
                column: "RegijaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizacionaJedinicas_NaucnaOblastId",
                table: "OrganizacionaJedinicas",
                column: "NaucnaOblastId");

            migrationBuilder.CreateIndex(
                name: "IX_Predmets_NppId",
                table: "Predmets",
                column: "NppId");

            migrationBuilder.CreateIndex(
                name: "IX_PrijavaIspitas_IspitniTerminId",
                table: "PrijavaIspitas",
                column: "IspitniTerminId");

            migrationBuilder.CreateIndex(
                name: "IX_PrijavaIspitas_SlusaPredmetId",
                table: "PrijavaIspitas",
                column: "SlusaPredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_SlusaPredmets_IzvodjenjePredmetaId",
                table: "SlusaPredmets",
                column: "IzvodjenjePredmetaId");

            migrationBuilder.CreateIndex(
                name: "IX_SlusaPredmets_UpisGodineId",
                table: "SlusaPredmets",
                column: "UpisGodineId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_KorisnikId",
                table: "Students",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_OpstinaPrebivalistaId",
                table: "Students",
                column: "OpstinaPrebivalistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_OpstinaRodjenjaId",
                table: "Students",
                column: "OpstinaRodjenjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Studiranjes_NppId",
                table: "Studiranjes",
                column: "NppId");

            migrationBuilder.CreateIndex(
                name: "IX_Studiranjes_StudentId",
                table: "Studiranjes",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPorukas_KorisnikId",
                table: "TicketPorukas",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPorukas_TicketId",
                table: "TicketPorukas",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPorukas_TicketId1",
                table: "TicketPorukas",
                column: "TicketId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IzvodjenjePredmetaId",
                table: "Tickets",
                column: "IzvodjenjePredmetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StudiranjeId",
                table: "Tickets",
                column: "StudiranjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketKategorijaId",
                table: "Tickets",
                column: "TicketKategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ZaposlenikId",
                table: "Tickets",
                column: "ZaposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_UpisGodines_AkademskaGodinaId",
                table: "UpisGodines",
                column: "AkademskaGodinaId");

            migrationBuilder.CreateIndex(
                name: "IX_UpisGodines_StudiranjeId",
                table: "UpisGodines",
                column: "StudiranjeId");

            migrationBuilder.CreateIndex(
                name: "IX_UplataStudijas_EvidentiranoKorisnikId",
                table: "UplataStudijas",
                column: "EvidentiranoKorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_UplataStudijas_UpisGodineId",
                table: "UplataStudijas",
                column: "UpisGodineId");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposleniks_KorisnikId",
                table: "Zaposleniks",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenjes_OrganizacionaJedinicaId",
                table: "Zaposlenjes",
                column: "OrganizacionaJedinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenjes_ZaposlenikId",
                table: "Zaposlenjes",
                column: "ZaposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenjes_ZaposlenjeMjestoId",
                table: "Zaposlenjes",
                column: "ZaposlenjeMjestoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AngaziranNaPredmets");

            migrationBuilder.DropTable(
                name: "Notifikacijas");

            migrationBuilder.DropTable(
                name: "PrijavaIspitas");

            migrationBuilder.DropTable(
                name: "TicketPorukas");

            migrationBuilder.DropTable(
                name: "UplataStudijas");

            migrationBuilder.DropTable(
                name: "Zaposlenjes");

            migrationBuilder.DropTable(
                name: "IspitniTermins");

            migrationBuilder.DropTable(
                name: "SlusaPredmets");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "ZaposlenjeMjestos");

            migrationBuilder.DropTable(
                name: "IspitniRoks");

            migrationBuilder.DropTable(
                name: "UpisGodines");

            migrationBuilder.DropTable(
                name: "IzvodjenjePredmetas");

            migrationBuilder.DropTable(
                name: "TicketKategorijas");

            migrationBuilder.DropTable(
                name: "Zaposleniks");

            migrationBuilder.DropTable(
                name: "Studiranjes");

            migrationBuilder.DropTable(
                name: "Predmets");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "NPPs");

            migrationBuilder.DropTable(
                name: "Korisniks");

            migrationBuilder.DropTable(
                name: "Opstinas");

            migrationBuilder.DropTable(
                name: "AkademskaGodinas");

            migrationBuilder.DropTable(
                name: "Odsjeks");

            migrationBuilder.DropTable(
                name: "Regijas");

            migrationBuilder.DropTable(
                name: "OrganizacionaJedinicas");

            migrationBuilder.DropTable(
                name: "NaucnaOblasts");
        }
    }
}
