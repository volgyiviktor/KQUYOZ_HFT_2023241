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
                    new Game(){Id=1, Title="Tony Hawk's Pro Skater 2", ReleaseYear=2010, Metascore=91},
                    new Game(){Id=2, Title="Spider-Man: Shattered Dimensions", ReleaseYear=2010, Metascore=76},
                    new Game(){Id=3, Title="GoldenEye 007", ReleaseYear=2010, Metascore=81},
                    new Game(){Id=4, Title="Call of Duty: Black Ops", ReleaseYear=2010, Metascore=87},
                    new Game(){Id=5, Title="Spider-Man: Edge of Time", ReleaseYear=2011, Metascore=57},
                    new Game(){Id=6, Title="Call of Duty: Modern Warfare 3", ReleaseYear=2011, Metascore=88},
                    new Game(){Id=7, Title="Prototype 2", ReleaseYear=2012, Metascore=74},
                    new Game(){Id=8, Title="Destiny", ReleaseYear=2014, Metascore=76},
                    new Game(){Id=9, Title="Crash Bandicoot: N. Sane Trilogy", ReleaseYear=2018, Metascore=80},
                    new Game(){Id=10, Title="Spyro: Reignited Trilogy", ReleaseYear=2018, Metascore=82},
                    new Game(){Id=11, Title="Sekiro: Shadows Die Twice", ReleaseYear=2019, Metascore=90},

                    new Game(){Id=12, Title="Mass Effect 2", ReleaseYear=2010, Metascore=96},
                    new Game(){Id=13, Title="Dante's Inferno", ReleaseYear=2010, Metascore=73},
                    new Game(){Id=14, Title="Battlefield Bad Company 2", ReleaseYear=2010, Metascore=88},
                    new Game(){Id=15, Title="Mirror's Edge", ReleaseYear=2010, Metascore=79},
                    new Game(){Id=16, Title="Skate 3", ReleaseYear=2010, Metascore=80},
                    new Game(){Id=17, Title="The Sims 3", ReleaseYear=2010, Metascore=86},
                    new Game(){Id=18, Title="Rock Band 3", ReleaseYear=2010, Metascore=93},
                    new Game(){Id=19, Title="Need for Speed: Hot Pursuit", ReleaseYear=2010, Metascore=88},
                    new Game(){Id=20, Title="Dead Space 2", ReleaseYear=2011, Metascore=90},
                    new Game(){Id=21, Title="Dragon Age II", ReleaseYear=2011, Metascore=79},
                    new Game(){Id=22, Title="Crysis 2", ReleaseYear=2011, Metascore=84},
                    new Game(){Id=23, Title="Dragon Age: Inquisition", ReleaseYear=2014, Metascore=85},
                    new Game(){Id=24, Title="Star Wars Battlefront II", ReleaseYear=2017, Metascore=68},
                    new Game(){Id=25, Title="A Way Out", ReleaseYear=2018, Metascore=78},
                    new Game(){Id=26, Title="Battlefield V", ReleaseYear=2018, Metascore=81},
                    new Game(){Id=27, Title="Apex Legends", ReleaseYear=2019, Metascore=89},

                    new Game(){Id=28, Title="Jak and Daxter: The Precursor Legacy", ReleaseYear=2001, Metascore=90},
                    new Game(){Id=29, Title="Jak II", ReleaseYear=2003, Metascore=87},
                    new Game(){Id=30, Title="Jak 3", ReleaseYear=2004, Metascore=84},
                    new Game(){Id=31, Title="Uncharted: Drake's Fortune", ReleaseYear=2007, Metascore=88},
                    new Game(){Id=32, Title="Uncharted 2: Among Thieves", ReleaseYear=2009, Metascore=96},
                    new Game(){Id=33, Title="Uncharted 3: Drake's Deception", ReleaseYear=2011, Metascore=92},
                    new Game(){Id=34, Title="The Last of Us", ReleaseYear=2013, Metascore=95},
                    new Game(){Id=35, Title="Uncharted 4: A Thief's End", ReleaseYear=2016, Metascore=93},
                    new Game(){Id=36, Title="The Last of Us Part II", ReleaseYear=2020, Metascore=93},

                    new Game(){Id=37, Title="Fallout 3", ReleaseYear=2008, Metascore=93},
                    new Game(){Id=38, Title="The Elder Scrolls V: Skyrim", ReleaseYear=2011, Metascore=96},
                    new Game(){Id=39, Title="Fallout 4", ReleaseYear=2015, Metascore=87},
                    new Game(){Id=40, Title="Fallout 76", ReleaseYear=2018, Metascore=52},
                    new Game(){Id=41, Title="Starfield", ReleaseYear=2023, Metascore=83},

                    new Game(){Id=42, Title="Crazy Taxi", ReleaseYear=2010, Metascore=59},
                    new Game(){Id=43, Title="Sonic Colors", ReleaseYear=2010, Metascore=78},
                    new Game(){Id=44, Title="Yakuza 4", ReleaseYear=2010, Metascore=78},
                    new Game(){Id=45, Title="Sonic Generations", ReleaseYear=2011, Metascore=77},
                    new Game(){Id=46, Title="Jet Set Radio", ReleaseYear=2012, Metascore=70},
                    new Game(){Id=47, Title="Yakuza 5", ReleaseYear=2012, Metascore=83},
                    new Game(){Id=48, Title="Judgment", ReleaseYear=2018, Metascore=80},
                    new Game(){Id=49, Title="Yakuza 0", ReleaseYear=2017, Metascore=85},
                    new Game(){Id=50, Title="Fist of the North Star: Lost Paradise", ReleaseYear=2018, Metascore=72},
                    new Game(){Id=51, Title="Yakuza Kiwami", ReleaseYear=2019, Metascore=80},
                    new Game(){Id=52, Title="Yakuza Kiwami 2", ReleaseYear=2019, Metascore=85},
                    new Game(){Id=53, Title="Lost Judgment", ReleaseYear=2021, Metascore=82},
                }
            );
            modelBuilder.Entity<Developer>().HasData(new Developer[]
                {
                    new Developer(){Id=1, Name="Activision"},
                    new Developer(){Id=2, Name="Electronic Arts"},
                    new Developer(){Id=3, Name="Naughty Dog"},
                    new Developer(){Id=4, Name="Bethesda Game Studios"},
                    new Developer(){Id=5, Name="Sega"},
                }
            );
            modelBuilder.Entity<GameAndDeveloper>().HasData(new GameAndDeveloper[]
                {
                    new GameAndDeveloper(){Id=1, GameId=1, DeveloperId=1},
                    new GameAndDeveloper(){Id=2, GameId=2, DeveloperId=1},
                    new GameAndDeveloper(){Id=3, GameId=3, DeveloperId=1},
                    new GameAndDeveloper(){Id=4, GameId=4, DeveloperId=1},
                    new GameAndDeveloper(){Id=5, GameId=5, DeveloperId=1},
                    new GameAndDeveloper(){Id=6, GameId=1, DeveloperId=1},
                    new GameAndDeveloper(){Id=7, GameId=2, DeveloperId=1},
                    new GameAndDeveloper(){Id=8, GameId=3, DeveloperId=1},
                    new GameAndDeveloper(){Id=9, GameId=4, DeveloperId=1},
                    new GameAndDeveloper(){Id=10, GameId=5, DeveloperId=1},
                    new GameAndDeveloper(){Id=11, GameId=1, DeveloperId=1},

                    new GameAndDeveloper(){Id=12, GameId=2, DeveloperId=2},
                    new GameAndDeveloper(){Id=13, GameId=3, DeveloperId=2},
                    new GameAndDeveloper(){Id=14, GameId=4, DeveloperId=2},
                    new GameAndDeveloper(){Id=15, GameId=5, DeveloperId=2},
                    new GameAndDeveloper(){Id=16, GameId=1, DeveloperId=2},
                    new GameAndDeveloper(){Id=17, GameId=2, DeveloperId=2},
                    new GameAndDeveloper(){Id=18, GameId=3, DeveloperId=2},
                    new GameAndDeveloper(){Id=19, GameId=4, DeveloperId=2},
                    new GameAndDeveloper(){Id=20, GameId=5, DeveloperId=2},
                    new GameAndDeveloper(){Id=21, GameId=1, DeveloperId=2},
                    new GameAndDeveloper(){Id=22, GameId=2, DeveloperId=2},
                    new GameAndDeveloper(){Id=23, GameId=3, DeveloperId=2},
                    new GameAndDeveloper(){Id=24, GameId=4, DeveloperId=2},
                    new GameAndDeveloper(){Id=25, GameId=5, DeveloperId=2},
                    new GameAndDeveloper(){Id=26, GameId=1, DeveloperId=2},
                    new GameAndDeveloper(){Id=27, GameId=2, DeveloperId=2},

                    new GameAndDeveloper(){Id=28, GameId=3, DeveloperId=3},
                    new GameAndDeveloper(){Id=29, GameId=4, DeveloperId=3},
                    new GameAndDeveloper(){Id=30, GameId=5, DeveloperId=3},
                    new GameAndDeveloper(){Id=31, GameId=1, DeveloperId=3},
                    new GameAndDeveloper(){Id=32, GameId=2, DeveloperId=3},
                    new GameAndDeveloper(){Id=33, GameId=3, DeveloperId=3},
                    new GameAndDeveloper(){Id=34, GameId=4, DeveloperId=3},
                    new GameAndDeveloper(){Id=35, GameId=5, DeveloperId=3},
                    new GameAndDeveloper(){Id=36, GameId=1, DeveloperId=3},

                    new GameAndDeveloper(){Id=37, GameId=2, DeveloperId=4},
                    new GameAndDeveloper(){Id=38, GameId=3, DeveloperId=4},
                    new GameAndDeveloper(){Id=39, GameId=4, DeveloperId=4},
                    new GameAndDeveloper(){Id=40, GameId=5, DeveloperId=4},
                    new GameAndDeveloper(){Id=41, GameId=1, DeveloperId=4},

                    new GameAndDeveloper(){Id=42, GameId=2, DeveloperId=5},
                    new GameAndDeveloper(){Id=43, GameId=3, DeveloperId=5},
                    new GameAndDeveloper(){Id=44, GameId=4, DeveloperId=5},
                    new GameAndDeveloper(){Id=45, GameId=5, DeveloperId=5},
                    new GameAndDeveloper(){Id=46, GameId=1, DeveloperId=5},
                    new GameAndDeveloper(){Id=47, GameId=2, DeveloperId=5},
                    new GameAndDeveloper(){Id=48, GameId=3, DeveloperId=5},
                    new GameAndDeveloper(){Id=49, GameId=4, DeveloperId=5},
                    new GameAndDeveloper(){Id=50, GameId=5, DeveloperId=5},
                    new GameAndDeveloper(){Id=51, GameId=1, DeveloperId=5},
                }
            );
        }
    }

}