using System;
using System.Collections.Generic;
using System.Text;
using eUniverzitet.Data.Models;
using Ispit.Data.EntityModels;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Data
{
    public class MyContext:DbContext
    {

        public MyContext(DbContextOptions<MyContext> x):base(x)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Odjeljenje>()
            //    .HasOne(x => x.Razrednik)
            //    .WithMany()
            //    .HasForeignKey(x => x.RazrednikID)
            //    .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Predmet> Predmet { get; set; }
        public DbSet<DodjeljenPredmet> DodjeljenPredmet { get; set; }
        public DbSet<Ucenik> Ucenik { get; set; }
        public DbSet<OdjeljenjeStavka> OdjeljenjeStavka { get; set; }
        public DbSet<Odjeljenje> Odjeljenje { get; set; }
        public DbSet<Nastavnik> Nastavnik { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<AutorizacijskiToken> AutorizacijskiToken { get; set; }
    }
}
