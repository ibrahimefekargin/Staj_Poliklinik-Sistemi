using Microsoft.EntityFrameworkCore;
using Poliklinik.Models;
using PoliklinikSistemi.Models;

namespace Poliklinik.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Doktor> Doktorlar { get; set; }

        public DbSet<PoliklinikBirim> PoliklinikBirimler { get; set; }

        public DbSet<Randevu> Randevular { get; set; }

        public DbSet<SistemLog> SistemLoglar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doktor>().HasData(
                new Doktor { DoktorId = 1, AdSoyad = "Dr. Ahmet Yılmaz", Brans = "Dahiliye" },
                new Doktor { DoktorId = 2, AdSoyad = "Dr. Ayşe Demir", Brans = "Kardiyoloji" },
                new Doktor { DoktorId = 3, AdSoyad = "Dr. Mehmet Kaya", Brans = "Göz Hastalıkları" }
            );
        }
    }
}
