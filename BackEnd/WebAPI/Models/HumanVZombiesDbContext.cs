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
        public DbSet<WebAPI.Models.Domain.User> User { get; set; }


        public HumanVZombiesDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding data
            //modelBuilder.Entity<Player>().HasData(new Player() { Id = 1, Name = "Thor", Alias = "Lord of Thunder", Gender = "Male" });
            //modelBuilder.Entity<Player>().HasData(new Player() { Id = 2, Name = "Ironman", Alias = "Tony Stark", Gender = "Male" });
            //modelBuilder.Entity<Player>().HasData(new Player() { Id = 3, Name = "Black Widow", Alias = "Natasha Romanoff", Gender = "Female" });
            //modelBuilder.Entity<Player>().HasData(new Player() { Id = 4, Name = "Spiderman", Alias = "Peter Parker", Gender = "Male" });
            //modelBuilder.Entity<Player>().HasData(new Player() { Id = 5, Name = "Batman", Alias = "Bruce Wayne", Gender = "Male" });

            //    modelBuilder.Entity<Franchise>().HasData(new Franchise() { Id = 1, Name = "MCU", Description = "Marvel's cinematic universe." });
            //    modelBuilder.Entity<Franchise>().HasData(new Franchise() { Id = 2, Name = "DNT", Description = "Dark Knight Trilogy" });
            //    modelBuilder.Entity<Franchise>().HasData(new Franchise() { Id = 3, Name = "TCU", Description = "Titanic's cinematic universe." });

            //    modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 1, Title = "The Avengers", Genre = "Action", Year = 2012, Director = "Joss Whedon", FranchiseId = 1 });
            //    modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 2, Title = "Avengers: Endgame", Genre = "Action", Year = 2019, Director = "Anthony Russo, Joe Russo", FranchiseId = 1 });
            //    modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 3, Title = "The Dark Knight", Genre = "Action", Year = 2008, Director = "Christopher Nolan" });
            //    modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 4, Title = "Titanic", Genre = "Action", Year = 1997, Director = "James Camera" });

            //    // Seeding m2m Player-Movie.
            //    modelBuilder.Entity<Player>()
            //        .HasMany(p => p.Movies)
            //        .WithMany(m => m.Players)
            //        .UsingEntity<Dictionary<string, object>>(
            //            "PlayerMovie",
            //            r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
            //            l => l.HasOne<Player>().WithMany().HasForeignKey("PlayerId"),
            //            je =>
            //            {
            //                je.HasKey("PlayerId", "MovieId");
            //                je.HasData(
            //                    new { PlayerId = 1, MovieId = 1 },
            //                    new { PlayerId = 1, MovieId = 2 },
            //                    new { PlayerId = 2, MovieId = 1 },
            //                    new { PlayerId = 2, MovieId = 2 },
            //                    new { PlayerId = 3, MovieId = 1 },
            //                    new { PlayerId = 3, MovieId = 2 },
            //                    new { PlayerId = 4, MovieId = 2 },
            //                    new { PlayerId = 5, MovieId = 3 }
            //                );
            //            });
        }
    }
}
