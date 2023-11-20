using KQUYOZ_HFT_2023241.Models;
using KQUYOZ_HFT_2023241.Repository.Database;
using KQUYOZ_HFT_2023241.Repository.GenericRepository;
using KQUYOZ_HFT_2023241.Repository.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KQUYOZ_HFT_2023241.Repository.ModelRepositories
{
    public class GameAndDeveloperRepository : Repository<GameAndDeveloper>, IRepository<GameAndDeveloper>
    {
        public GameAndDeveloperRepository(GamesDbContext ctx) : base(ctx)
        {
        }

        public override GameAndDeveloper Read(int id)
        {
            return ctx.GameAndDevelopers.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(GameAndDeveloper item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
