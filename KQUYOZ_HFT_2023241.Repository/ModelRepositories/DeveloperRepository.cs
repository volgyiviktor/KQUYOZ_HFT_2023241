﻿using KQUYOZ_HFT_2023241.Models;
using KQUYOZ_HFT_2023241.Repository.Database;
using KQUYOZ_HFT_2023241.Repository.GenericRepository;
using KQUYOZ_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQUYOZ_HFT_2023241.Repository.ModelRepositories
{
    public class DeveloperRepository : Repository<Developer>, IRepository<Developer>
    {
        public DeveloperRepository(GameDbContext ctx) : base(ctx)
        {
        }

        public override Developer Read(int id)
        {
            return ctx.Developers.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Developer item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
