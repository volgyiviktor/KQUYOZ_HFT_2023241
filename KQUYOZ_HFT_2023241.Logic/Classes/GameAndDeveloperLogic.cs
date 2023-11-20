using KQUYOZ_HFT_2023241.Models;
using KQUYOZ_HFT_2023241.Repository.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQUYOZ_HFT_2023241.Logic.Classes
{
    public class GameAndDeveloperLogic
    {
        IRepository<GameAndDeveloper> repo;

        public GameAndDeveloperLogic(IRepository<GameAndDeveloper> repo)
        {
            this.repo = repo;
        }

        public void Create(GameAndDeveloper item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public GameAndDeveloper Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<GameAndDeveloper> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(GameAndDeveloper item)
        {
            this.repo.Update(item);
        }
    }
}
