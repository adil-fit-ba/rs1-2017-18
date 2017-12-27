using Microsoft.EntityFrameworkCore;
using WebApplication5.EntityModels;

namespace WebApplication5.EF
{
    public class MojContext: DbContext
    {
        public MojContext(DbContextOptions<MojContext> options)
            : base(options)
        {
        }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Student> Studenti { get; set; }
        public DbSet<Opstina> Opstine { get; set; }

      
    }
}
