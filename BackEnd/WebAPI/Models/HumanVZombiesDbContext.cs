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
            modelBuilder.Entity<User>().HasData(new User() { Id = 1, FirstName = "James", LastName = "Smith" });
            modelBuilder.Entity<User>().HasData(new User() { Id = 2, FirstName = "James", LastName = "Glass" });
            modelBuilder.Entity<User>().HasData(new User() { Id = 3, FirstName = "Cameron", LastName = "Webcam" });
            modelBuilder.Entity<User>().HasData(new User() { Id = 4, FirstName = "Face", LastName = "Off" });
            modelBuilder.Entity<User>().HasData(new User() { Id = 5, FirstName = "Code", LastName = "Name" });
            modelBuilder.Entity<User>().HasData(new User() { Id = 6, FirstName = "Seven", LastName = "Eight" });
            modelBuilder.Entity<User>().HasData(new User() { Id = 7, FirstName = "Half", LastName = "Dan"  });
            //modelBuilder.Entity<User>().HasData(new User() { Id = 1, FirstName = "James", LastName = "Smith", UserName = "captain", Password = "1234"});
            //modelBuilder.Entity<User>().HasData(new User() { Id = 2, FirstName = "James", LastName = "Glass", UserName = "kid", Password = "1234" });
            //modelBuilder.Entity<User>().HasData(new User() { Id = 3, FirstName = "Cameron", LastName = "Webcam", UserName = "Luffy", Password = "1234" });
            //modelBuilder.Entity<User>().HasData(new User() { Id = 4, FirstName = "Face", LastName = "Off", UserName = "the", Password = "1234" });
            //modelBuilder.Entity<User>().HasData(new User() { Id = 5, FirstName = "Code", LastName = "Name", UserName = "pirate", Password = "1234" });
            //modelBuilder.Entity<User>().HasData(new User() { Id = 6, FirstName = "Seven", LastName = "Eight", UserName = "king", Password = "1234" });
            //modelBuilder.Entity<User>().HasData(new User() { Id = 7, FirstName = "Half", LastName = "Dan", UserName = "Water Law", Password = "58315687" });

            modelBuilder.Entity<Admin>().HasData(new Admin() { Id = 1, UserId = 6 });
            modelBuilder.Entity<Admin>().HasData(new Admin() { Id = 2, UserId = 7 });

            modelBuilder.Entity<Game>().HasData(new Game() { Id = 1, Name = "Game", AdminId = 1, GameState = Game.State.InProgress });
            modelBuilder.Entity<Game>().HasData(new Game() { Id = 2, Name = "Some Game", AdminId = 2, GameState = Game.State.Registation });
            modelBuilder.Entity<Game>().HasData(new Game() { Id = 3, Name = "This Game", AdminId = 1, GameState = Game.State.Complete });

            modelBuilder.Entity<Player>().HasData(new Player() { Id = 1, IsHuman = true, IsPatientZero = false, BiteCode = "Rando", GameId = 1, UserId = 1 });
            modelBuilder.Entity<Player>().HasData(new Player() { Id = 2, IsHuman = true, IsPatientZero = true, BiteCode = "mlyge", GameId = 1, UserId = 2 });
            modelBuilder.Entity<Player>().HasData(new Player() { Id = 3, IsHuman = false, IsPatientZero = true, BiteCode = "nerat", GameId = 2, UserId = 3 });
            modelBuilder.Entity<Player>().HasData(new Player() { Id = 4, IsHuman = true, IsPatientZero = false, BiteCode = "edCod", GameId = 2, UserId = 4 });
            modelBuilder.Entity<Player>().HasData(new Player() { Id = 5, IsHuman = true, IsPatientZero = false, BiteCode = "e", GameId = 3, UserId = 5 });

        }
    }
}
