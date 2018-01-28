using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RS1.Ispit.Web.Models;

namespace RS1.Ispit.Web.EF
{
    public class MojContext:DbContext
    {
        public MojContext():base("name=MojCS")
        {
            Database.SetInitializer(new MojDBInitializer());
        }

        public DbSet<VrstaPretrage> VrstaPretrage { get; set; }
        public DbSet<Ljekar> Ljekar { get; set; }
        public DbSet<Pacijent> Pacijent { get; set; }
        public DbSet<RezultatPretrage> RezultatPretrage { get; set; }
        public DbSet<Uputnica> Uputnica { get; set; }
        public DbSet<LabPretraga> LabPretraga { get; set; }
        public DbSet<Modalitet> Modalitet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //isključuje cascade delete i update zbog moguće greške "Table xyz may cause cycles or multiple cascade paths. Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints."
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Uputnica>()
                .HasOptional(s => s.LaboratorijLjekar)
                .WithMany()
                .HasForeignKey(s => s.LaboratorijLjekarId);

            modelBuilder.Entity<Uputnica>()
               .HasRequired(s => s.UputioLjekar)
               .WithMany()
               .HasForeignKey(s => s.UputioLjekarId);
        }
    }
}
