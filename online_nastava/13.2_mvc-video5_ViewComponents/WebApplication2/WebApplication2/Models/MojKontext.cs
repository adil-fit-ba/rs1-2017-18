using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class MojKontext:DbContext
    {
        public DbSet<Student> studenti { get; set; }
        public DbSet<Grad> gradovi { get; set; }

        public DbSet<Ocjena> ocjene { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=10.10.10.18;Database=Grupa1a;Trusted_Connection=False;MultipleActiveResultSets=true;User ID=sa;Password=test");
        }
    }
}
