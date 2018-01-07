using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplication1.db;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(VirtualEF))]
    partial class VirtualEFModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Grad", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("id");

                    b.ToTable("_gradovi");
                });

            modelBuilder.Entity("WebApplication1.Models.Student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GradId");

                    b.Property<string>("ime");

                    b.Property<bool>("isDL");

                    b.Property<string>("password");

                    b.Property<string>("prezime");

                    b.Property<string>("zanimanje");

                    b.HasKey("id");

                    b.HasIndex("GradId");

                    b.ToTable("_studenti");
                });

            modelBuilder.Entity("WebApplication1.Models.Student", b =>
                {
                    b.HasOne("WebApplication1.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
