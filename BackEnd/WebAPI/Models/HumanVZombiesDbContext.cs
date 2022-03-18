using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Domain;

namespace WebAPI.Models
{
    public class HumanVZombiesDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Admin> Admin { get; set; }


        public HumanVZombiesDbContext(DbContextOptions<HumanVZombiesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding data
            modelBuilder.Entity<User>().HasData(new User() { Id = 1, FirstName = "James", LastName = "Smith", UserName = "captain" });
            modelBuilder.Entity<User>().HasData(new User() { Id = 2, FirstName = "James", LastName = "Glass", UserName = "kid" });
            modelBuilder.Entity<User>().HasData(new User() { Id = 3, FirstName = "Cameron", LastName = "Webcam", UserName = "Luffy" });
            modelBuilder.Entity<User>().HasData(new User() { Id = 4, FirstName = "Face", LastName = "Off", UserName = "the" });
            modelBuilder.Entity<User>().HasData(new User() { Id = 5, FirstName = "Code", LastName = "Name", UserName = "pirate" });
            modelBuilder.Entity<User>().HasData(new User() { Id = 6, FirstName = "Seven", LastName = "Eight", UserName = "king" });
            modelBuilder.Entity<User>().HasData(new User() { Id = 7, FirstName = "Half", LastName = "Dan", UserName = "Water Law" });

            modelBuilder.Entity<Admin>().HasData(new Admin() { Id = 1, UserId = 6 });
            modelBuilder.Entity<Admin>().HasData(new Admin() { Id = 2, UserId = 7 });

            modelBuilder.Entity<Game>().HasData(new Game() { Id = 1, Name = "Game", AdminId = 1, GameState = Game.State.InProgress });
            modelBuilder.Entity<Game>().HasData(new Game() { Id = 2, Name = "Some Game", AdminId = 2, GameState = Game.State.Registration });
            modelBuilder.Entity<Game>().HasData(new Game() { Id = 3, Name = "This Game", AdminId = 1, GameState = Game.State.Complete });

            modelBuilder.Entity<Player>().HasData(new Player() { Id = 1, IsHuman = true, IsPatientZero = false, BiteCode = "Rando", GameId = 1, UserId = 1 });
            modelBuilder.Entity<Player>().HasData(new Player() { Id = 2, IsHuman = true, IsPatientZero = true, BiteCode = "mlyge", GameId = 1, UserId = 2 });
            modelBuilder.Entity<Player>().HasData(new Player() { Id = 3, IsHuman = false, IsPatientZero = true, BiteCode = "nerat", GameId = 2, UserId = 3 });
            modelBuilder.Entity<Player>().HasData(new Player() { Id = 4, IsHuman = true, IsPatientZero = false, BiteCode = "edCod", GameId = 2, UserId = 4 });
            modelBuilder.Entity<Player>().HasData(new Player() { Id = 5, IsHuman = true, IsPatientZero = false, BiteCode = "e", GameId = 3, UserId = 5 });

        }
    }
}
