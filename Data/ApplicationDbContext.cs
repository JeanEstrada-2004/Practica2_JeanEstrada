using Microsoft.EntityFrameworkCore;
using Practica2_JeanEstrada.Models;

namespace Practica2_JeanEstrada.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Adopter> Adopters { get; set; }
        public DbSet<Adoption> Adoptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación uno a uno: Pet puede tener solo una Adoption
            modelBuilder.Entity<Adoption>()
                .HasOne(a => a.Pet)
                .WithOne(p => p.Adoption)
                .HasForeignKey<Adoption>(a => a.PetId)
                .OnDelete(DeleteBehavior.Restrict);  // Opcional: evita que se borre la mascota si se borra la adopción

            // Relación muchos a uno: muchos Adoptions por un Adopter
            modelBuilder.Entity<Adoption>()
                .HasOne(a => a.Adopter)
                .WithMany(ad => ad.Adoptions)
                .HasForeignKey(a => a.AdopterId);
        }
    }
}
