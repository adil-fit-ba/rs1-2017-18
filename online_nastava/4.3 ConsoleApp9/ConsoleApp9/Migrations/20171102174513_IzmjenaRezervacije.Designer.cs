using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ConsoleApp9.EF;
using ConsoleApp9.model;

namespace ConsoleApp9.Migrations
{
    [DbContext(typeof(MojContext))]
    [Migration("20171102174513_IzmjenaRezervacije")]
    partial class IzmjenaRezervacije
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsoleApp9.model.Klijent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImePrezime");

                    b.Property<int?>("OpstinaId");

                    b.HasKey("Id");

                    b.HasIndex("OpstinaId");

                    b.ToTable("Klijent");
                });

            modelBuilder.Entity("ConsoleApp9.model.Opstina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Opstina");
                });

            modelBuilder.Entity("ConsoleApp9.model.Rezervacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumRezervacije");

                    b.Property<int>("KlijentId");

                    b.Property<int?>("SobaId");

                    b.HasKey("Id");

                    b.HasIndex("KlijentId");

                    b.HasIndex("SobaId");

                    b.ToTable("Rezervacija");
                });

            modelBuilder.Entity("ConsoleApp9.model.Soba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Naziv");

                    b.Property<int>("Sprat");

                    b.Property<int>("TipSobe");

                    b.HasKey("Id");

                    b.ToTable("Soba");
                });

            modelBuilder.Entity("ConsoleApp9.model.Klijent", b =>
                {
                    b.HasOne("ConsoleApp9.model.Opstina", "Opstina")
                        .WithMany()
                        .HasForeignKey("OpstinaId");
                });

            modelBuilder.Entity("ConsoleApp9.model.Rezervacija", b =>
                {
                    b.HasOne("ConsoleApp9.model.Klijent", "Klijent")
                        .WithMany("Rezervacijas")
                        .HasForeignKey("KlijentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ConsoleApp9.model.Soba", "Soba")
                        .WithMany()
                        .HasForeignKey("SobaId");
                });
        }
    }
}
