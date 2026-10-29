using Microsoft.EntityFrameworkCore;
using VirtualPetAdoption.Models;

namespace VirtualPetAdoption.Data
{
    public class PetAdoptionContext : DbContext
    {
        public PetAdoptionContext(DbContextOptions<PetAdoptionContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().HasData(
                new Pet { Id = 1, Name = "Fluffy", Species = "Cat",
                    Description = "A calm cat who enjoys naps.",
                    Emoji = "🐱", EnergyLevel = 2 },
                new Pet { Id = 2, Name = "Rex", Species = "Dog",
                    Description = "A dog who loves to play fetch.",
                    Emoji = "🐶", EnergyLevel = 5 },
                new Pet { Id = 3, Name = "Nibbles", Species = "Rabbit",
                    Description = "A friendly rabbit with medium energy.",
                    Emoji = "🐰", EnergyLevel = 3 }
            );
        }
    }
}

