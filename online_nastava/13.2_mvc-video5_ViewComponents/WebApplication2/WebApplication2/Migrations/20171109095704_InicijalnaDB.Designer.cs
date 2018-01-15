using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplication2.Models;

namespace WebApplication2.Migrations
{
    [DbContext(typeof(MojKontext))]
    [Migration("20171109095704_InicijalnaDB")]
    partial class InicijalnaDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication2.Models.Grad", b =>
                {
                    b.Property<int>("GradID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("GradID");

                    b.ToTable("gradovi");
                });

            modelBuilder.Entity("WebApplication2.Models.Student", b =>
                {
                    b.Property<int>("SudentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GradID");

                    b.Property<string>("Ime");

                    b.Property<string>("Index");

                    b.Property<string>("Prezime");

                    b.HasKey("SudentID");

                    b.HasIndex("GradID");

                    b.ToTable("studenti");
                });

            modelBuilder.Entity("WebApplication2.Models.Student", b =>
                {
                    b.HasOne("WebApplication2.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID");
                });
        }
    }
}
