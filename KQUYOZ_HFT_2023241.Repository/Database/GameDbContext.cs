using KQUYOZ_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQUYOZ_HFT_2023241.Repository.Database
{
    public class GameDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public GameDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseLazyLoadingProxies().UseInMemoryDatabase("gameDB");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasOne(g => g.Developer)
                .WithMany(d => d.Game)
                .HasForeignKey(g => g.DeveloperId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.Publisher)
                .WithMany(d => d.Game)
                .HasForeignKey(g => g.PublisherId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Developer>().HasData(new Developer[]
                {
                    new Developer(){Id=1, Name="Neversoft"},
                    new Developer(){Id=2, Name="Beenox"},
                    new Developer(){Id=3, Name="Eurocom"},
                    new Developer(){Id=4, Name="Treyarch"},
                    new Developer(){Id=5, Name="Infinity Ward"},
                    new Developer(){Id=6, Name="Radical Entertainment"},
                    new Developer(){Id=7, Name="Bungie"},
                    new Developer(){Id=8, Name="Vicarious Visions"},
                    new Developer(){Id=9, Name="Toys for Bob"},
                    new Developer(){Id=10, Name="FromSoftware"},

                    new Developer(){Id=11, Name="BioWare"},
                    new Developer(){Id=12, Name="Visceral Games"},
                    new Developer(){Id=13, Name="DICE"},
                    new Developer(){Id=14, Name="EA Black Box"},
                    new Developer(){Id=15, Name="Maxis"},
                    new Developer(){Id=16, Name="Harmonix"},
                    new Developer(){Id=17, Name="Criterion Games"},
                    new Developer(){Id=18, Name="Crytek"},
                    new Developer(){Id=19, Name="Hazelight Studios"},
                    new Developer(){Id=20, Name="Respawn Entertainment"},

                    new Developer(){Id=21, Name="Naugthy Dog"},
                    new Developer(){Id=22, Name="Santa Monica Studio"},
                    new Developer(){Id=23, Name="Insomniac Games"},


                    new Developer(){Id=24, Name="Bethesda Game Studios"},

                    new Developer(){Id=25, Name="Hitmaker"},
                    new Developer(){Id=26, Name="Sonic Team"},
                    new Developer(){Id=27, Name="Ryu Ga Gotoku Studio"},
                    new Developer(){Id=28, Name="Smilebit"}
                }
            );

            modelBuilder.Entity<Publisher>().HasData(new Publisher[]
            {
                    new Publisher(){Id=1, Name="Activision"},
                    new Publisher(){Id=2, Name="Electronic Arts"},
                    new Publisher(){Id=3, Name="Sony Computer Entertainment"},
                    new Publisher(){Id=4, Name="Bethesda Softworks"},
                    new Publisher(){Id=5, Name="Sega"}
                }
            );

            modelBuilder.Entity<Game>().HasData(new Game[]
                {
                    new Game(){Id=1, Title="Tony Hawk's Pro Skater 2", ReleaseYear=2010, Metascore=91, DeveloperId=1, PublisherId=1},
                    new Game(){Id=2, Title="Spider-Man: Shattered Dimensions", ReleaseYear=2010, Metascore=76, DeveloperId=2, PublisherId=1},
                    new Game(){Id=3, Title="GoldenEye 007", ReleaseYear=2010, Metascore=81, DeveloperId=3, PublisherId=1},
                    new Game(){Id=4, Title="Call of Duty: Black Ops", ReleaseYear=2010, Metascore=87, DeveloperId=4, PublisherId=1},
                    new Game(){Id=5, Title="Spider-Man: Edge of Time", ReleaseYear=2011, Metascore=57, DeveloperId=2, PublisherId=1},
                    new Game(){Id=6, Title="Call of Duty: Modern Warfare 3", ReleaseYear=2011, Metascore=88, DeveloperId=5, PublisherId=1},
                    new Game(){Id=7, Title="Prototype 2", ReleaseYear=2012, Metascore=74, DeveloperId=6, PublisherId=1},
                    new Game(){Id=8, Title="Destiny", ReleaseYear=2014, Metascore=76, DeveloperId=7, PublisherId=1},
                    new Game(){Id=9, Title="Crash Bandicoot: N. Sane Trilogy", ReleaseYear=2018, Metascore=80, DeveloperId=8, PublisherId=1},
                    new Game(){Id=10, Title="Spyro: Reignited Trilogy", ReleaseYear=2018, Metascore=82, DeveloperId=9, PublisherId=1},
                    new Game(){Id=11, Title="Sekiro: Shadows Die Twice", ReleaseYear=2019, Metascore=90, DeveloperId=10, PublisherId=1},

                    new Game(){Id=12, Title="Mass Effect 2", ReleaseYear=2010, Metascore=96, DeveloperId=11, PublisherId=2},
                    new Game(){Id=13, Title="Dante's Inferno", ReleaseYear=2010, Metascore=73, DeveloperId=12, PublisherId=2},
                    new Game(){Id=14, Title="Battlefield Bad Company 2", ReleaseYear=2010, Metascore=88, DeveloperId=13, PublisherId=2},
                    new Game(){Id=15, Title="Mirror's Edge", ReleaseYear=2010, Metascore=79, DeveloperId=13, PublisherId=2},
                    new Game(){Id=16, Title="Skate 3", ReleaseYear=2010, Metascore=80, DeveloperId=14, PublisherId=2},
                    new Game(){Id=17, Title="The Sims 3", ReleaseYear=2010, Metascore=86, DeveloperId=15, PublisherId=2},
                    new Game(){Id=18, Title="Rock Band 3", ReleaseYear=2010, Metascore=93, DeveloperId=16, PublisherId=2},
                    new Game(){Id=19, Title="Need for Speed: Hot Pursuit", ReleaseYear=2010, Metascore=88, DeveloperId=17, PublisherId=2},
                    new Game(){Id=20, Title="Dead Space 2", ReleaseYear=2011, Metascore=90, DeveloperId=12, PublisherId=2},
                    new Game(){Id=21, Title="Dragon Age II", ReleaseYear=2011, Metascore=79, DeveloperId=11, PublisherId=2},
                    new Game(){Id=22, Title="Crysis 2", ReleaseYear=2011, Metascore=84, DeveloperId=18, PublisherId=2},
                    new Game(){Id=23, Title="Dragon Age: Inquisition", ReleaseYear=2014, Metascore=85, DeveloperId=11, PublisherId=2},
                    new Game(){Id=24, Title="Star Wars Battlefront II", ReleaseYear=2017, Metascore=68, DeveloperId=13, PublisherId=2},
                    new Game(){Id=25, Title="A Way Out", ReleaseYear=2018, Metascore=78, DeveloperId=19, PublisherId=2},
                    new Game(){Id=26, Title="Battlefield V", ReleaseYear=2018, Metascore=81, DeveloperId=13, PublisherId=2},
                    new Game(){Id=27, Title="Apex Legends", ReleaseYear=2019, Metascore=89, DeveloperId=20, PublisherId=2},

                    new Game(){Id=28, Title="Jak and Daxter: The Precursor Legacy", ReleaseYear=2001, Metascore=90, DeveloperId=21, PublisherId=3},
                    new Game(){Id=29, Title="God of War", ReleaseYear=2005, Metascore=94, DeveloperId=22, PublisherId=3},
                    new Game(){Id=30, Title="Uncharted: Drake's Fortune", ReleaseYear=2007, Metascore=88, DeveloperId=21, PublisherId=3},
                    new Game(){Id=31, Title="Uncharted 2: Among Thieves", ReleaseYear=2009, Metascore=96, DeveloperId=21, PublisherId=3},
                    new Game(){Id=32, Title="Uncharted 3: Drake's Deception", ReleaseYear=2011, Metascore=92, DeveloperId=21, PublisherId=3},
                    new Game(){Id=33, Title="God of War: Ascension", ReleaseYear=2013, Metascore=80, DeveloperId=22, PublisherId=3},
                    new Game(){Id=35, Title="The Last of Us", ReleaseYear=2013, Metascore=95, DeveloperId=21, PublisherId=3},
                    new Game(){Id=36, Title="Marvel's Spider-Man", ReleaseYear=2018, Metascore=87, DeveloperId=23, PublisherId=3},

                    new Game(){Id=37, Title="Fallout 3", ReleaseYear=2008, Metascore=93, DeveloperId=24, PublisherId=4},
                    new Game(){Id=38, Title="The Elder Scrolls V: Skyrim", ReleaseYear=2011, Metascore=96, DeveloperId=24, PublisherId=4},
                    new Game(){Id=39, Title="Fallout 4", ReleaseYear=2015, Metascore=87, DeveloperId=24, PublisherId=4},
                    new Game(){Id=40, Title="Fallout 76", ReleaseYear=2018, Metascore=52, DeveloperId=24, PublisherId=4},
                    new Game(){Id=41, Title="Starfield", ReleaseYear=2023, Metascore=83, DeveloperId=24, PublisherId=4},

                    new Game(){Id=42, Title="Crazy Taxi", ReleaseYear=2010, Metascore=59, DeveloperId=25, PublisherId=5},
                    new Game(){Id=43, Title="Sonic Colors", ReleaseYear=2010, Metascore=78, DeveloperId=26, PublisherId=5},
                    new Game(){Id=44, Title="Yakuza 4", ReleaseYear=2010, Metascore=78, DeveloperId=27, PublisherId=5},
                    new Game(){Id=45, Title="Sonic Generations", ReleaseYear=2011, Metascore=77, DeveloperId=26, PublisherId=5},
                    new Game(){Id=46, Title="Jet Set Radio", ReleaseYear=2012, Metascore=70, DeveloperId=28, PublisherId=5},
                    new Game(){Id=47, Title="Yakuza 5", ReleaseYear=2012, Metascore=83, DeveloperId=27, PublisherId=5},
                    new Game(){Id=48, Title="Judgment", ReleaseYear=2018, Metascore=80, DeveloperId=27, PublisherId=5},
                    new Game(){Id=49, Title="Yakuza 0", ReleaseYear=2017, Metascore=85, DeveloperId=27, PublisherId=5},
                    new Game(){Id=50, Title="Fist of the North Star: Lost Paradise", ReleaseYear=2018, Metascore=72, DeveloperId=27, PublisherId=5},
                    new Game(){Id=51, Title="Yakuza Kiwami", ReleaseYear=2019, Metascore=80, DeveloperId=27, PublisherId=5},
                    new Game(){Id=52, Title="Yakuza Kiwami 2", ReleaseYear=2019, Metascore=85, DeveloperId=27, PublisherId=5},
                    new Game(){Id=53, Title="Lost Judgment", ReleaseYear=2021, Metascore=82, DeveloperId=27, PublisherId=5}
                }
            );

        }
    }
}
