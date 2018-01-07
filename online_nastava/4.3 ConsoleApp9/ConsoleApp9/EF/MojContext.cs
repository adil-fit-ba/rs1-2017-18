using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp9.model;

namespace ConsoleApp9.EF
{
    public class MojContext: DbContext
    {
        public DbSet<Klijent> Klijent { get; set; }
        public DbSet<Opstina> Opstina { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }
        public DbSet<Soba> Soba { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
            optionsBuilder.UseSqlServer("Server=10.10.10.18;Database=BrojIndeksa2;Trusted_Connection=False;MultipleActiveResultSets=true;User ID=sa;Password=test");

          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
        }
    }

   
}
