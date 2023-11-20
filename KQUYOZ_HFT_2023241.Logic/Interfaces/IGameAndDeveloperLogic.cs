using KQUYOZ_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQUYOZ_HFT_2023241.Logic.Interfaces
{
    public interface IGameAndDeveloperLogic
    {
        void Create(GameAndDeveloper item);
        void Delete(int id);
        GameAndDeveloper Read(int id);
        IQueryable<GameAndDeveloper> ReadAll();
        void Update(GameAndDeveloper item);
    }
}
