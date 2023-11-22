using KQUYOZ_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQUYOZ_HFT_2023241.Logic.Interfaces
{
    public interface IGameLogic
    {
        void Create(Game item);
        void Delete(int id);
        Game Read(int id);
        IQueryable<Game> ReadAll();
        void Update(Game item);

        IQueryable<Developer> AllDeveloperFromThatYear(int year);
        IQueryable<Publisher> AllPublisherFromThatYear(int year);
        double AverageRatingOfDeveloperGames(int id);
        double AverageRatingOfPublisherGames(int id);
        Developer DeveloperOfGameOfTheYear(int year);

    }
}
