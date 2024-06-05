using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HaberPortali.Models
{
    public class HaberContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public HaberContext(DbContextOptions<HaberContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

         modelBuilder.Entity<Haber>().HasData(new Haber() { HaberId = 1, HaberBaslik = "Gündem", Tarih = "10.03.2024", IsActive = true });
         modelBuilder.Entity<Haber>().HasData(new Haber() { HaberId = 2, HaberBaslik = "Tarih", Tarih = "06.01.2023", IsActive = false });
         modelBuilder.Entity<Haber>().HasData(new Haber() { HaberId = 3, HaberBaslik = "Borsa", Tarih = "07.05.2024", IsActive = true });
         modelBuilder.Entity<Haber>().HasData(new Haber() { HaberId = 4, HaberBaslik = "Magazin", Tarih = "18.11.2023", IsActive = true });
        }

        public DbSet<Haber> Products { get; set; }


    }
}
