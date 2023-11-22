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
    public class PublisherLogic : IPublisherLogic
    {
        IRepository<Publisher> repo;

        public PublisherLogic(IRepository<Publisher> repo)
        {
            this.repo = repo;
        }

        public void Create(Publisher item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Publisher Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Publisher> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Publisher item)
        {
            this.repo.Update(item);
        }
    }
}
