﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokemonApi.Data;

namespace Pokemon.Migrations
{
    [DbContext(typeof(PokemonContext))]
    partial class PokemonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PokemonApi.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PokemonApi.Models.CustomerFavourite", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("PokemonId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId", "PokemonId");

                    b.HasIndex("PokemonId");

                    b.ToTable("CustomerFavourite");
                });

            modelBuilder.Entity("PokemonApi.Models.Move", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Accuracy")
                        .HasColumnType("int");

                    b.Property<int>("BasePower")
                        .HasColumnType("int");

                    b.Property<string>("Effect")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("PokemonId")
                        .HasColumnType("int");

                    b.Property<int>("PowerPoints")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("Move");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Accuracy = 100,
                            BasePower = 90,
                            Effect = "The user stirs ip a violent blizzard and attacks everything around it.",
                            Name = "Petal Blizzard",
                            PokemonId = 3,
                            PowerPoints = 15
                        },
                        new
                        {
                            Id = 2,
                            Accuracy = 100,
                            BasePower = 120,
                            Effect = "The user attacks the target by scattering petals for two or three turns. The user then becomes confused.",
                            Name = "Petal Dance",
                            PokemonId = 3,
                            PowerPoints = 10
                        },
                        new
                        {
                            Id = 3,
                            Accuracy = 100,
                            BasePower = 40,
                            Effect = "A Physical attack in which the user charges and slams into the target with its whole body.",
                            Name = "Tackle",
                            PokemonId = 3,
                            PowerPoints = 35
                        },
                        new
                        {
                            Id = 4,
                            Accuracy = 100,
                            BasePower = 0,
                            Effect = "The user growls in an endearing way, making opposing Pokémon less wary. This lowers their Attack stats.",
                            Name = "Growl",
                            PokemonId = 3,
                            PowerPoints = 40
                        },
                        new
                        {
                            Id = 5,
                            Accuracy = 95,
                            BasePower = 75,
                            Effect = "The user attacks with a blade of air that slices even the sky. This may also make the target flinch.",
                            Name = "Air Slash",
                            PokemonId = 6,
                            PowerPoints = 15
                        },
                        new
                        {
                            Id = 6,
                            Accuracy = 100,
                            BasePower = 80,
                            Effect = "The user slashes the target with huge sharp claws.",
                            Name = "Dragon Claw",
                            PokemonId = 6,
                            PowerPoints = 15
                        },
                        new
                        {
                            Id = 7,
                            Accuracy = 90,
                            BasePower = 95,
                            Effect = "The user attacks by exhaling hot breath on opposing Pokémon. This may also leave those Pokémon with a burn.",
                            Name = "Heat Wave",
                            PokemonId = 6,
                            PowerPoints = 10
                        },
                        new
                        {
                            Id = 8,
                            Accuracy = 100,
                            BasePower = 40,
                            Effect = "Hard, pointed, sharp claws rake the target to inflict damage.",
                            Name = "Scratch",
                            PokemonId = 6,
                            PowerPoints = 35
                        },
                        new
                        {
                            Id = 9,
                            Accuracy = 100,
                            BasePower = 80,
                            Effect = "The user gathers all its light energy and releases it all at once. This may also lower the target's Sp. Def. stat.",
                            Name = "Flash Cannon",
                            PokemonId = 9,
                            PowerPoints = 10
                        },
                        new
                        {
                            Id = 10,
                            Accuracy = 100,
                            BasePower = 40,
                            Effect = "A Physical attack in which the user charges and slams into the target with its whole body.",
                            Name = "Tackle",
                            PokemonId = 9,
                            PowerPoints = 35
                        },
                        new
                        {
                            Id = 11,
                            Accuracy = 100,
                            BasePower = 0,
                            Effect = "The user wags its tail cutely, making opposing Pokémon less wary and lowering their Defense stats.",
                            Name = "Tail Whip",
                            PokemonId = 9,
                            PowerPoints = 30
                        },
                        new
                        {
                            Id = 12,
                            Accuracy = 100,
                            BasePower = 40,
                            Effect = "The target is blasted with a forceful shot of water.",
                            Name = "Water Gun",
                            PokemonId = 9,
                            PowerPoints = 25
                        });
                });

            modelBuilder.Entity("PokemonApi.Models.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Pokemon");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "There is a plant seed on its back right from the day this Pokémon is born. The seed slowly grows larger.",
                            Name = "Bulbasaur"
                        },
                        new
                        {
                            Id = 2,
                            Description = "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs.",
                            Name = "Ivysaur"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Its plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight.",
                            Name = "Venusaur"
                        },
                        new
                        {
                            Id = 4,
                            Description = "It has a preference for hot things. When it rains, steam is said to spout from the tip of its tail.",
                            Name = "Charmander"
                        },
                        new
                        {
                            Id = 5,
                            Description = "It has a barbaric nature. In battle, it whips its fiery tail around and slashes away with sharp claws.",
                            Name = "Charmeleon"
                        },
                        new
                        {
                            Id = 6,
                            Description = "It spits fire that is hot enough to melt boulders. It may cause forest fires by blowing flames.",
                            Name = "Charizard"
                        },
                        new
                        {
                            Id = 7,
                            Description = "When it retracts its long neck into its shell, it squirts out water with vigorous force.",
                            Name = "Squirtle"
                        },
                        new
                        {
                            Id = 8,
                            Description = "It is recognized as a symbol of longevity. If its shell has algae on it, that Wartortle is very old.",
                            Name = "Wartortle"
                        },
                        new
                        {
                            Id = 9,
                            Description = "It crushes its foe under its heavy body to cause fainting. In a pinch, it will withdraw inside its shell.",
                            Name = "Blastoise"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokemonApi.Models.CustomerFavourite", b =>
                {
                    b.HasOne("PokemonApi.Models.Customer", "Customer")
                        .WithMany("Favourites")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonApi.Models.Pokemon", "Pokemon")
                        .WithMany()
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokemonApi.Models.Move", b =>
                {
                    b.HasOne("PokemonApi.Models.Pokemon", null)
                        .WithMany("Moves")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
