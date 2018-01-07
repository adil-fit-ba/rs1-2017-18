using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ConsoleApp2.EF;

namespace ConsoleApp2.Migrations
{
    [DbContext(typeof(MojContext))]
    partial class MojContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsoleApp2.model.Kupac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ime");

                    b.Property<int?>("OpstinaId");

                    b.HasKey("Id");

                    b.HasIndex("OpstinaId");

                    b.ToTable("Kupci");
                });

            modelBuilder.Entity("ConsoleApp2.model.Opstina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Opstine");
                });

            modelBuilder.Entity("ConsoleApp2.model.Kupac", b =>
                {
                    b.HasOne("ConsoleApp2.model.Opstina", "Opstina")
                        .WithMany()
                        .HasForeignKey("OpstinaId");
                });
        }
    }
}
