using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Models;

namespace WebAPI.Migrations
{
    [DbContext(typeof(HumanVZombiesDbContext))]
    partial class HumanVZombiesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Models.Domain.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Admin");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserId = 6
                        },
                        new
                        {
                            Id = 2,
                            UserId = 7
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Domain.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("GameState")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdminId = 1,
                            GameState = 1,
                            Name = "Game"
                        },
                        new
                        {
                            Id = 2,
                            AdminId = 2,
                            GameState = 0,
                            Name = "Some Game"
                        },
                        new
                        {
                            Id = 3,
                            AdminId = 1,
                            GameState = 2,
                            Name = "This Game"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Domain.KillsTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("KillsTable");
                });

            modelBuilder.Entity("WebAPI.Models.Domain.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BiteCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<bool>("IsHuman")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPatientZero")
                        .HasColumnType("bit");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BiteCode = "Rando",
                            GameId = 1,
                            IsHuman = true,
                            IsPatientZero = false,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BiteCode = "mlyge",
                            GameId = 1,
                            IsHuman = true,
                            IsPatientZero = true,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            BiteCode = "nerat",
                            GameId = 2,
                            IsHuman = false,
                            IsPatientZero = true,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            BiteCode = "edCod",
                            GameId = 2,
                            IsHuman = true,
                            IsPatientZero = false,
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            BiteCode = "e",
                            GameId = 3,
                            IsHuman = true,
                            IsPatientZero = false,
                            UserId = 5
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("KeycloakId")
                        .HasColumnType("nvarchar(max)");
                        
                    b.Property<int?>("KillsTableId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("KillsTableId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "James",
                            LastName = "Smith",
                            UserName = "captain"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "James",
                            LastName = "Glass",
                            UserName = "kid"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Cameron",
                            LastName = "Webcam",
                            UserName = "Luffy"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Face",
                            LastName = "Off",
                            UserName = "the"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Code",
                            LastName = "Name",
                            UserName = "pirate"
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "Seven",
                            LastName = "Eight",
                            UserName = "king"
                        },
                        new
                        {
                            Id = 7,
                            FirstName = "Half",
                            LastName = "Dan",
                            UserName = "Water Law"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Domain.Admin", b =>
                {
                    b.HasOne("WebAPI.Models.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebAPI.Models.Domain.Game", b =>
                {
                    b.HasOne("WebAPI.Models.Domain.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId");

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("WebAPI.Models.Domain.KillsTable", b =>
                {
                    b.HasOne("WebAPI.Models.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebAPI.Models.Domain.Player", b =>
                {
                    b.HasOne("WebAPI.Models.Domain.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId");

                    b.HasOne("WebAPI.Models.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebAPI.Models.Domain.User", b =>
                {
                    b.HasOne("WebAPI.Models.Domain.KillsTable", null)
                        .WithMany("Users")
                        .HasForeignKey("KillsTableId");
                });

            modelBuilder.Entity("WebAPI.Models.Domain.Game", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("WebAPI.Models.Domain.KillsTable", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
