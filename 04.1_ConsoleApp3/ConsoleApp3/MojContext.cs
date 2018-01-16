using ConsoleApp3.model;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class MojContext : DbContext
    {
        public DbSet<Klijent> Klijent { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }
        public DbSet<Soba> Soba { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=BrojIndeksa;Trusted_Connection=True;MultipleActiveResultSets=true;User ID=sa;Password=test");
        }
    }
}
