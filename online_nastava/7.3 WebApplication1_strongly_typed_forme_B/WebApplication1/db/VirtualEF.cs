using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.db
{
    public class VirtualEF : DbContext
    {
        public DbSet<Student> _studenti { get; set; }
        public DbSet<Grad> _gradovi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=10.10.10.18;Database=NovoImeBaze2;Trusted_Connection=False;MultipleActiveResultSets=true;User ID=sa;Password=test");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    //modelBuilder.Entity<Student>();
        //    //modelBuilder.Entity<Grad>();

        //}
    }
}
