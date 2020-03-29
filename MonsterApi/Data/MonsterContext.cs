using Microsoft.EntityFrameworkCore;
using MonsterApi.Models;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MonsterApi.Data
{
    public class MonsterContext : IdentityDbContext
    {
        public MonsterContext(DbContextOptions<MonsterContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Models.Monster>()
                .HasMany(p => p.Moves)
                .WithOne()
                .IsRequired()
                .HasForeignKey("MonsterId"); //Shadow property
            builder.Entity<Models.Monster>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Models.Monster>().Property(p => p.Description).IsRequired().HasMaxLength(256);
            builder.Entity<Move>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Move>().Property(p => p.PowerPoints).IsRequired();
            builder.Entity<Move>().Property(p => p.BasePower);
            builder.Entity<Move>().Property(p => p.Accuracy).IsRequired();
            builder.Entity<Move>().Property(p => p.Effect).IsRequired().HasMaxLength(256);
            builder.Entity<Customer>().Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>().Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>().Property(c => c.Email).IsRequired().HasMaxLength(100);
            builder.Entity<Customer>().Ignore(c => c.FavouriteMonster);

            builder.Entity<CustomerFavourite>().HasKey(f => new { f.CustomerId, f.MonsterId });
            builder.Entity<CustomerFavourite>().HasOne(f => f.Customer).WithMany(u => u.Favourites).HasForeignKey(f => f.CustomerId);
            builder.Entity<CustomerFavourite>().HasOne(f => f.Monster).WithMany().HasForeignKey(f => f.MonsterId);


            //Another way to seed the database
            builder.Entity<Models.Monster>().HasData(
                new Models.Monster { Id = 1, Name = "Bulbasaur", Description = "There is a plant seed on its back right from the day this Pokémon is born. The seed slowly grows larger.", HealthPoints = 45, Attack = 49, Defense = 49, Speed = 45},
                new Models.Monster { Id = 2, Name = "Ivysaur", Description = "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs.", HealthPoints = 60, Attack = 62, Defense = 63, Speed = 60 },
                new Models.Monster { Id = 3, Name = "Venusaur", Description = "Its plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight.", HealthPoints = 80, Attack = 82, Defense = 83, Speed = 80 },
                new Models.Monster { Id = 4, Name = "Charmander", Description = "It has a preference for hot things. When it rains, steam is said to spout from the tip of its tail.", HealthPoints = 39, Attack = 52, Defense = 43, Speed = 65 },
                new Models.Monster { Id = 5, Name = "Charmeleon", Description = "It has a barbaric nature. In battle, it whips its fiery tail around and slashes away with sharp claws.", HealthPoints = 58, Attack = 64, Defense = 58, Speed = 80 },
                new Models.Monster { Id = 6, Name = "Charizard", Description = "It spits fire that is hot enough to melt boulders. It may cause forest fires by blowing flames.", HealthPoints = 78, Attack = 84, Defense = 78, Speed = 100 },
                new Models.Monster { Id = 7, Name = "Squirtle", Description = "When it retracts its long neck into its shell, it squirts out water with vigorous force.", HealthPoints = 44, Attack = 48, Defense = 65, Speed = 43 },
                new Models.Monster { Id = 8, Name = "Wartortle", Description = "It is recognized as a symbol of longevity. If its shell has algae on it, that Wartortle is very old.", HealthPoints = 59, Attack = 63, Defense = 80, Speed = 58 },
                new Models.Monster { Id = 9, Name = "Blastoise", Description = "It crushes its foe under its heavy body to cause fainting. In a pinch, it will withdraw inside its shell.", HealthPoints = 79, Attack = 83, Defense = 100, Speed = 78 }
            );

            builder.Entity<Move>().HasData(
                    //Shadow property can be used for the foreign key, in combination with anonymous objects
                    new { Id = 1, Name = "Petal Blizzard", PowerPoints = 15, BasePower = 90, Accuracy = 100, Effect = "The user stirs ip a violent blizzard and attacks everything around it.", MonsterId = 3 },
                    new { Id = 2, Name = "Petal Dance", PowerPoints = 10, BasePower = 120, Accuracy = 100, Effect = "The user attacks the target by scattering petals for two or three turns. The user then becomes confused.", MonsterId = 3 },
                    new { Id = 3, Name = "Tackle", PowerPoints = 35, BasePower = 40, Accuracy = 100, Effect = "A Physical attack in which the user charges and slams into the target with its whole body.", MonsterId = 3 },
                    new { Id = 4, Name = "Growl", PowerPoints = 40, BasePower = 0, Accuracy = 100, Effect = "The user growls in an endearing way, making opposing Pokémon less wary. This lowers their Attack stats.", MonsterId = 3 },
                    new { Id = 5, Name = "Air Slash", PowerPoints = 15, BasePower = 75, Accuracy = 95, Effect = "The user attacks with a blade of air that slices even the sky. This may also make the target flinch.", MonsterId = 6 },
                    new { Id = 6, Name = "Dragon Claw", PowerPoints = 15, BasePower = 80, Accuracy = 100, Effect = "The user slashes the target with huge sharp claws.", MonsterId = 6 },
                    new { Id = 7, Name = "Heat Wave", PowerPoints = 10, BasePower = 95, Accuracy = 90, Effect = "The user attacks by exhaling hot breath on opposing Pokémon. This may also leave those Pokémon with a burn.", MonsterId = 6 },
                    new { Id = 8, Name = "Scratch", PowerPoints = 35, BasePower = 40, Accuracy = 100, Effect = "Hard, pointed, sharp claws rake the target to inflict damage.", MonsterId = 6 },
                    new { Id = 9, Name = "Flash Cannon", PowerPoints = 10, BasePower = 80, Accuracy = 100, Effect = "The user gathers all its light energy and releases it all at once. This may also lower the target's Sp. Def. stat.", MonsterId = 9 },
                    new { Id = 10, Name = "Tackle", PowerPoints = 35, BasePower = 40, Accuracy = 100, Effect = "A Physical attack in which the user charges and slams into the target with its whole body.", MonsterId = 9 },
                    new { Id = 11, Name = "Tail Whip", PowerPoints = 30, BasePower = 0, Accuracy = 100, Effect = "The user wags its tail cutely, making opposing Pokémon less wary and lowering their Defense stats.", MonsterId = 9 },
                    new { Id = 12, Name = "Water Gun", PowerPoints = 25, BasePower = 40, Accuracy = 100, Effect = "The target is blasted with a forceful shot of water.", MonsterId = 9 }
            );
        }

        public DbSet<Models.Monster> Monster { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}