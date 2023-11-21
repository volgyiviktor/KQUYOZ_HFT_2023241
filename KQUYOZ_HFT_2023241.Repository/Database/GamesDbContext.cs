using Microsoft.EntityFrameworkCore;
using KQUYOZ_HFT_2023241.Models;

namespace KQUYOZ_HFT_2023241.Repository.Database
{
    public class GamesDbContext : DbContext
    {
        public DbSet<GameAndDeveloper> GameAndDevelopers { get; set; }

        public GamesDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseLazyLoadingProxies().UseInMemoryDatabase("gamesDB");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameAndDeveloper>()
                .HasOne(gad => gad.Developer)
                .WithMany(d => d.GameAndDeveloper)
                .HasForeignKey(gad => gad.DeveloperId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GameAndDeveloper>()
                .HasOne(gad => gad.Game)
                .WithMany(d => d.GameAndDeveloper)
                .HasForeignKey(gad => gad.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Game>().HasData(new Game[]
                {
                    new Game(){Id=1, Title="Call of Duty"},
                    new Game(){Id=2, Title="Battlefield"},
                    new Game(){Id=3, Title="Need for Speed"},
                    new Game(){Id=4, Title="Crash Bandicoot"},
                    new Game(){Id=5, Title="Uncharted"},
                }
            );
            modelBuilder.Entity<Developer>().HasData(new Developer[]
                {
                    new Developer(){Id=1, Name="Activision"},
                    new Developer(){Id=2, Name="Electronic Arts"},
                    new Developer(){Id=3, Name="Naughty Dogs"},
                }
            );
            modelBuilder.Entity<GameAndDeveloper>().HasData(new GameAndDeveloper[]
                {
                    new GameAndDeveloper(){Id=1, GameId=1, DeveloperId=1},
                    new GameAndDeveloper(){Id=2, GameId=2, DeveloperId=2},
                    new GameAndDeveloper(){Id=3, GameId=3, DeveloperId=1},
                    new GameAndDeveloper(){Id=4, GameId=4, DeveloperId=2},
                    new GameAndDeveloper(){Id=5, GameId=5, DeveloperId=3},
                }
            );
        }
    }

}