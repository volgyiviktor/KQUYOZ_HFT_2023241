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
    public class DeveloperLogic : IDeveloperLogic
    {
        IRepository<Developer> repo;

        public DeveloperLogic(IRepository<Developer> repo)
        {
            this.repo = repo;
        }

        public void Create(Developer item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Developer Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Developer> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Developer item)
        {
            this.repo.Update(item);
        }
    }
}
