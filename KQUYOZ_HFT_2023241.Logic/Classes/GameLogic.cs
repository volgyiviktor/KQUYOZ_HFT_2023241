using KQUYOZ_HFT_2023241.Logic.Interfaces;
using KQUYOZ_HFT_2023241.Models;
using KQUYOZ_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQUYOZ_HFT_2023241.Logic.Classes
{
    public class GameLogic : IGameLogic
    {
        IRepository<Game> repo;

        public GameLogic(IRepository<Game> repo)
        {
            this.repo = repo;
        }

        public void Create(Game item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Game Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Game> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Game item)
        {
            this.repo.Update(item);
        }



        public IQueryable<Developer> AllDeveloperFromThatYear(int year)
        {
            return this.repo.ReadAll().Where(t=>t.ReleaseYear==year).Select(t=>t.Developer);
        }

        public IQueryable<Publisher> AllPublisherFromThatYear(int year)
        {
            return this.repo.ReadAll().Where(t => t.ReleaseYear == year).Select(t => t.Publisher);
        }

        public double AverageRatingOfDeveloperGames(int id)
        {
            return this.repo.ReadAll().Where(t => t.DeveloperId == id).Average(t => t.Metascore);
        }

        public double AverageRatingOfPublisherGames(int id)
        {
            return this.repo.ReadAll().Where(t => t.PublisherId == id).Average(t => t.Metascore);
        }
        public Developer DeveloperOfGameOfTheYear(int year)
        {
            return this.repo.ReadAll().Where(t => t.ReleaseYear == year).OrderByDescending(t => t.Metascore).Select(t => t.Developer).First();
        }

    }
}
