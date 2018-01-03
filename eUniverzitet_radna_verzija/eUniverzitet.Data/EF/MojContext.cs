using eUniverzitet.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace eUniverzitet.Data.EF
{
    public class MojContext:DbContext
    {
        public MojContext(DbContextOptions<MojContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IzvodjenjePredmeta>()
                .HasOne(pt => pt.Predmet)
                .WithMany()
                .HasForeignKey(pt => pt.PredmetId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UpisGodine>()
                .HasOne(pt => pt.Studiranje)
                .WithMany()
                .HasForeignKey(pt => pt.StudiranjeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IspitniTermin>()
                .HasOne(pt => pt.IzvodjenjePredmeta)
                .WithMany()
                .HasForeignKey(pt => pt.IzvodjenjePredmetaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SlusaPredmet>()
                .HasOne(pt => pt.UpisGodine)
                .WithMany()
                .HasForeignKey(pt => pt.UpisGodineId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TicketPoruka>()
                .HasOne(pt => pt.Ticket)
                .WithMany()
                .HasForeignKey(pt => pt.TicketId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PrijavaIspita>()
                .HasOne(pt => pt.SlusaPredmet)
                .WithMany()
                .HasForeignKey(pt => pt.SlusaPredmetId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<AkademskaGodina> AkademskaGodinas { set; get; }
        public DbSet<Notifikacija> Notifikacijas { set; get; }
        public DbSet<AngaziranNaPredmet> AngaziranNaPredmets { set; get; }
        public DbSet<Fakultet> Fakultets { set; get; }
        public DbSet<Rektorat> Rektorats { set; get; }
        public DbSet<IzvodjenjePredmeta> IzvodjenjePredmetas { set; get; }
        public DbSet<Korisnik> Korisniks { set; get; }
        public DbSet<NaucnaOblast> NaucnaOblasts { set; get; }
        public DbSet<NastavnoOsoblje> NastavnoOsobljes { set; get; }
        public DbSet<NPP> NPPs { set; get; }
        public DbSet<Odsjek> Odsjeks { set; get; }
        public DbSet<Opstina> Opstinas { set; get; }
        public DbSet<OrganizacionaJedinica> OrganizacionaJedinicas { set; get; }

        public DbSet<Institut> Instituts { set; get; }
        public DbSet<Predmet> Predmets { set; get; }
        public DbSet<PrijavaIspita> PrijavaIspitas { set; get; }
        public DbSet<IspitniRok> IspitniRoks { set; get; }
        public DbSet<IspitniTermin> IspitniTermins { set; get; }

        public DbSet<Regija> Regijas { set; get; }
        public DbSet<SlusaPredmet> SlusaPredmets { set; get; }
        public DbSet<Student> Students { set; get; }
        public DbSet<Studiranje> Studiranjes { set; get; }
        public DbSet<UpisGodine> UpisGodines { set; get; }
        public DbSet<UplataStudija> UplataStudijas { set; get; }
        public DbSet<Zaposlenik> Zaposleniks { set; get; }
        public DbSet<Zaposlenje> Zaposlenjes { set; get; }

        public DbSet<ZaposlenjeMjesto> ZaposlenjeMjestos { set; get; }


        public DbSet<Ticket> Tickets { set; get; }
        public DbSet<TicketPoruka> TicketPorukas { set; get; }
        public DbSet<TicketKategorija> TicketKategorijas { set; get; }
    }
}
