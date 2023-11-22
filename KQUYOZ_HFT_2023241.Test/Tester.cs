using KQUYOZ_HFT_2023241.Logic.Classes;
using KQUYOZ_HFT_2023241.Logic.Interfaces;
using KQUYOZ_HFT_2023241.Models;
using KQUYOZ_HFT_2023241.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KQUYOZ_HFT_2023241.Test
{
    [TestFixture]
    public class Tester
    {
        DeveloperLogic developerlogic;
        PublisherLogic publisherlogic;
        GameLogic gamelogic;
        Mock<IRepository<Developer>> mockDeveloperRepo;
        Mock<IRepository<Publisher>> mockPublisherRepo;
        Mock<IRepository<Game>> mockGameRepo;

        [SetUp]
        public void Init()
        {
            Developer d1 = new Developer() { Id = 1, Name = "DeveloperA" };
            Developer d2 = new Developer() { Id = 2, Name = "DeveloperB" };
            Developer d3 = new Developer() { Id = 3, Name = "DeveloperC" };

            Publisher p1 = new Publisher() { Id = 1, Name = "PublisherA" };
            Publisher p2 = new Publisher() { Id = 2, Name = "PublisherA" };
            Publisher p3 = new Publisher() { Id = 3, Name = "PublisherA" };

            Game g1 = new Game() { Id = 1, Metascore = 10, ReleaseYear = 2001, Title = "GameA", DeveloperId = 1, PublisherId = 1, Developer = d1, Publisher = p1 };
            Game g2 = new Game() { Id = 2, Metascore = 20, ReleaseYear = 2002, Title = "GameB", DeveloperId = 1, PublisherId = 1, Developer = d1, Publisher = p1 };
            Game g3 = new Game() { Id = 3, Metascore = 30, ReleaseYear = 2004, Title = "GameC", DeveloperId = 2, PublisherId = 2, Developer = d2, Publisher = p2 };
            Game g4 = new Game() { Id = 4, Metascore = 40, ReleaseYear = 2004, Title = "GameD", DeveloperId = 3, PublisherId = 3, Developer = d3, Publisher = p3 };

            mockDeveloperRepo = new Mock<IRepository<Developer>>();
            mockDeveloperRepo.Setup(m => m.ReadAll()).Returns(new List<Developer>() { d1, d2, d3 }.AsQueryable());
            developerlogic = new DeveloperLogic(mockDeveloperRepo.Object);


            mockPublisherRepo = new Mock<IRepository<Publisher>>();
            mockPublisherRepo.Setup(m => m.ReadAll()).Returns(new List<Publisher>() { p1, p2, p3 }.AsQueryable());
            publisherlogic = new PublisherLogic(mockPublisherRepo.Object);

            mockGameRepo = new Mock<IRepository<Game>>();
            mockGameRepo.Setup(m => m.ReadAll()).Returns(new List<Game>() { g1, g2, g3, g4 }.AsQueryable());
            gamelogic = new GameLogic(mockGameRepo.Object);
        }

        [Test]
        public void AllDeveloperFromThatYearTest()
        {
            List<Developer> dev = gamelogic.AllDeveloperFromThatYear(2004);
            Assert.That(dev[0].Id == 2 && dev[1].Id == 3);
        }

        [Test]
        public void AllPublisherFromThatYearTest()
        {
            var pub = gamelogic.AllPublisherFromThatYear(2004);
            Assert.That(pub[0].Id == 2 && pub[1].Id == 3);
        }

        [Test]
        public void AverageRatingOfDeveloperGamesTest()
        {
            double avg = gamelogic.AverageRatingOfDeveloperGames(1);
            Assert.That(avg == 15);
        }

        [Test]
        public void AverageRatingOfPublisherGamesTest()
        {
            double avg = gamelogic.AverageRatingOfPublisherGames(1);
            Assert.That(avg == 15);
        }

        [Test]
        public void DeveloperOfGameOfTheYearTest()
        {
            var dev = gamelogic.DeveloperOfGameOfTheYear(2004);
            Assert.That(dev.Id == 3);
        }

        [Test]
        public void CreateGameTestWithCorrectTitle()
        {
            Game game = new Game() { Title = "AA" };
            gamelogic.Create(game);
            mockGameRepo.Verify(r => r.Create(game), Times.Once);
        }

        [Test]
        public void CreateGameTestWithIncorrectTitle()
        {
            Game game = new Game() { Title = "A" };
            try
            {
                gamelogic.Create(game);
            }
            catch
            {

            }
            mockGameRepo.Verify(r => r.Create(game), Times.Never);
        }

        [Test]
        public void CreatePublisherTestWithIncorrectTitle()
        {
            Publisher publisher = new Publisher() { Name = "A" };
            try
            {
                publisherlogic.Create(publisher);
            }
            catch
            {

            }
            mockPublisherRepo.Verify(r => r.Create(publisher), Times.Never);
        }

        [Test]
        public void CreateDeveloperTestWithIncorrectTitle()
        {
            Developer developer = new Developer() { Name = "A" };
            try
            {
                developerlogic.Create(developer);
            }
            catch
            {

            }
            mockDeveloperRepo.Verify(r => r.Create(developer), Times.Never);
        }

        [Test]
        public void DeleteGameTest()
        {
            gamelogic.Delete(1);
            mockGameRepo.Verify(r => r.Delete(1), Times.Once);
        }

    }
}
