﻿using KQUYOZ_HFT_2023241.Models;
using KQUYOZ_HFT_2023241.Repository.Database;
using KQUYOZ_HFT_2023241.Repository.GenericRepository;
using KQUYOZ_HFT_2023241.Repository.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQUYOZ_HFT_2023241.Repository.ModelRepositories
{
    public class GameRepository : Repository<Game>, IRepository<Game>
    {
        public GameRepository(GamesDbContext ctx) : base(ctx)
        {
        }

        public override Game Read(int id)
        {
            return ctx.GameAndDevelopers.Select(t => t.Game).FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Game item)
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