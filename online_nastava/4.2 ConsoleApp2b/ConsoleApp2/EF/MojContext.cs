
using ConsoleApp2.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.EF
{
    public class MojContext: DbContext
    {
        public DbSet<Kupac> Kupci { get; set; }

        public DbSet<Opstina> Opstine { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=10.10.10.18;Database=adil;Trusted_Connection=False;MultipleActiveResultSets=true;User ID=sa;Password=test");

        }
     
    }
}
