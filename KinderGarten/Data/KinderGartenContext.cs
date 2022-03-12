using KinderGarten.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace KinderGarten.Data
{
    public class KinderGartenContext : IdentityDbContext
    {
        public KinderGartenContext(DbContextOptions<KinderGartenContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DijeteIzlet>()
                .HasKey(c => new { c.DijeteID, c.IzletID });

            modelBuilder.Entity<DijeteOvlastenaOsoba>()
                .HasKey(c => new { c.DijeteID, c.OvlastenaOsobaID });

            modelBuilder.Entity<ZaposlenikSeminar>()
                .HasKey(c => new { c.ZaposlenikID, c.SeminarID });

            modelBuilder.Entity<DijeteAktivnost>()
                .HasKey(c => new { c.DijeteID, c.AktivnostID });

            modelBuilder.Entity<AktivnostZaposlenik>()
             .HasKey(c => new { c.AktivnostID, c.ZaposlenikID });

            modelBuilder.Entity<IdentityUserClaim<string>>().HasKey(p => new { p.Id });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IzletZaposlenici>()
             .HasKey(c => new { c.IzletID, c.ZaposlenikID });

        }
        public DbSet<IdentityUserClaim<string>> IdentityUserClaim { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Dijete> Dijete { get; set; }

        public DbSet<DijeteIzlet> DijeteIzlet { get; set; }
        public DbSet<DijeteAktivnost> DijeteAktivnost { get; set; }

        public DbSet<DijeteOvlastenaOsoba> DijeteOvlastenaOsoba { get; set; }

        public DbSet<Drzava> Drzava { get; set; }

        public DbSet<Evidencija> Evidencija { get; set; }

        public DbSet<Grad> Grad { get; set; }

        public DbSet<Grupa> Grupa { get; set; }

        public DbSet<Izlet> Izlet { get; set; }

        public DbSet<OvlastenaOsoba> OvlastenaOsoba { get; set; }

        public DbSet<RadniList> RadniList { get; set; }

        public DbSet<Seminar> Seminar { get; set; }

        public DbSet<StrucnaSprema> StrucnaSprema { get; set; }

        public DbSet<Uplata> Uplata { get; set; }

        public DbSet<VrstaUplate> VrstaUplate { get; set; }

        public DbSet<Zanimanje> Zanimanje { get; set; }

        public DbSet<Zaposlenik> Zaposlenik { get; set; }

        public DbSet<ZaposlenikSeminar> ZaposlenikSeminar { get; set; }
        public DbSet<Roditelj> Roditelj { get; set; }
        public DbSet<Aktivnost> Aktivnost { get; set; }
        public DbSet<AktivnostZaposlenik> AktivnostZaposlenik { get; set; }
        public DbSet<IzletZaposlenici> IzletZaposlenici { get; set; }

        

    }
}
