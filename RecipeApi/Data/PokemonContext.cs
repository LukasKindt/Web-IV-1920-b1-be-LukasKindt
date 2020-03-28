using Microsoft.EntityFrameworkCore;
using PokemonApi.Models;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PokemonApi.Data
{
    public class PokemonContext : IdentityDbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Models.Pokemon>()
                .HasMany(p => p.Moves)
                .WithOne()
                .IsRequired()
                .HasForeignKey("PokemonId"); //Shadow property
            builder.Entity<Models.Pokemon>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Models.Pokemon>().Property(p => p.Description).IsRequired().HasMaxLength(256);
            builder.Entity<Move>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Move>().Property(p => p.PowerPoints).IsRequired();
            builder.Entity<Move>().Property(p => p.BasePower);
            builder.Entity<Move>().Property(p => p.Accuracy).IsRequired();
            builder.Entity<Move>().Property(p => p.Effect).IsRequired().HasMaxLength(256);
            builder.Entity<Customer>().Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>().Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>().Property(c => c.Email).IsRequired().HasMaxLength(100);
            builder.Entity<Customer>().Ignore(c => c.FavouritePokemon);

            builder.Entity<CustomerFavourite>().HasKey(f => new { f.CustomerId, f.PokemonId });
            builder.Entity<CustomerFavourite>().HasOne(f => f.Customer).WithMany(u => u.Favourites).HasForeignKey(f => f.CustomerId);
            builder.Entity<CustomerFavourite>().HasOne(f => f.Pokemon).WithMany().HasForeignKey(f => f.PokemonId);


            //Another way to seed the database
            builder.Entity<Models.Pokemon>().HasData(
                new Models.Pokemon { Id = 1, Name = "Bulbasaur", Description = "There is a plant seed on its back right from the day this Pokémon is born. The seed slowly grows larger."},
                new Models.Pokemon { Id = 2, Name = "Ivysaur", Description = "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs." },
                new Models.Pokemon { Id = 3, Name = "Venusaur", Description = "Its plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight." },
                new Models.Pokemon { Id = 4, Name = "Charmander", Description = "It has a preference for hot things. When it rains, steam is said to spout from the tip of its tail." },
                new Models.Pokemon { Id = 5, Name = "Charmeleon", Description = "It has a barbaric nature. In battle, it whips its fiery tail around and slashes away with sharp claws." },
                new Models.Pokemon { Id = 6, Name = "Charizard", Description = "It spits fire that is hot enough to melt boulders. It may cause forest fires by blowing flames." },
                new Models.Pokemon { Id = 7, Name = "Squirtle", Description = "When it retracts its long neck into its shell, it squirts out water with vigorous force." },
                new Models.Pokemon { Id = 8, Name = "Wartortle", Description = "It is recognized as a symbol of longevity. If its shell has algae on it, that Wartortle is very old." },
                new Models.Pokemon { Id = 9, Name = "Blastoise", Description = "It crushes its foe under its heavy body to cause fainting. In a pinch, it will withdraw inside its shell." }
            );

            builder.Entity<Move>().HasData(
                    //Shadow property can be used for the foreign key, in combination with anonymous objects
                    new { Id = 1, Name = "Petal Blizzard", PowerPoints = 15, BasePower = 90, Accuracy = 100, Effect = "The user stirs ip a violent blizzard and attacks everything around it.", PokemonId = 3 },
                    new { Id = 2, Name = "Petal Dance", PowerPoints = 10, BasePower = 120, Accuracy = 100, Effect = "The user attacks the target by scattering petals for two or three turns. The user then becomes confused.", PokemonId = 3 },
                    new { Id = 3, Name = "Tackle", PowerPoints = 35, BasePower = 40, Accuracy = 100, Effect = "A Physical attack in which the user charges and slams into the target with its whole body.", PokemonId = 3 },
                    new { Id = 4, Name = "Growl", PowerPoints = 40, BasePower = 0, Accuracy = 100, Effect = "The user growls in an endearing way, making opposing Pokémon less wary. This lowers their Attack stats.", PokemonId = 3 },
                    new { Id = 5, Name = "Air Slash", PowerPoints = 15, BasePower = 75, Accuracy = 95, Effect = "The user attacks with a blade of air that slices even the sky. This may also make the target flinch.", PokemonId = 6 },
                    new { Id = 6, Name = "Dragon Claw", PowerPoints = 15, BasePower = 80, Accuracy = 100, Effect = "The user slashes the target with huge sharp claws.", PokemonId = 6 },
                    new { Id = 7, Name = "Heat Wave", PowerPoints = 10, BasePower = 95, Accuracy = 90, Effect = "The user attacks by exhaling hot breath on opposing Pokémon. This may also leave those Pokémon with a burn.", PokemonId = 6 },
                    new { Id = 8, Name = "Scratch", PowerPoints = 35, BasePower = 40, Accuracy = 100, Effect = "Hard, pointed, sharp claws rake the target to inflict damage.", PokemonId = 6 },
                    new { Id = 9, Name = "Flash Cannon", PowerPoints = 10, BasePower = 80, Accuracy = 100, Effect = "The user gathers all its light energy and releases it all at once. This may also lower the target's Sp. Def. stat.", PokemonId = 9 },
                    new { Id = 10, Name = "Tackle", PowerPoints = 35, BasePower = 40, Accuracy = 100, Effect = "A Physical attack in which the user charges and slams into the target with its whole body.", PokemonId = 9 },
                    new { Id = 11, Name = "Tail Whip", PowerPoints = 30, BasePower = 0, Accuracy = 100, Effect = "The user wags its tail cutely, making opposing Pokémon less wary and lowering their Defense stats.", PokemonId = 9 },
                    new { Id = 12, Name = "Water Gun", PowerPoints = 25, BasePower = 40, Accuracy = 100, Effect = "The target is blasted with a forceful shot of water.", PokemonId = 9 }
            );
        }

        public DbSet<Models.Pokemon> Pokemon { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}