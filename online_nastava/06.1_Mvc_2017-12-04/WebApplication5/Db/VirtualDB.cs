using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication5.EntityModels;

namespace WebApplication5.Db
{
    public class VirtualDB: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=10.10.10.18;Database=RS1_online;Trusted_Connection=true;MultipleActiveResultSets=true;User ID=sa;Password=test");
        }

        public DbSet<Student> _studenti { get; set; }
        public DbSet<Opstina> _opstine { get; set; }

      
    }
}
