using Linkup.Data;
using Linkup.Models;
using Linkup.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linkup.Services
{
    public class SkillService : ISkillService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public SkillService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task Create(Skill skill)
        {
            applicationDbContext.Add(skill);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task Update(int id, Skill skill)
        {
            var skillFromDb = await applicationDbContext.Skills.FindAsync(id);

            if (skillFromDb.Id == skillFromDb.Id)
            {
                skillFromDb.Name = skill.Name;
                await applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<Skill> GetById(int id)
        {
            return await applicationDbContext.Skills
               .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Skill>> GetAll()
        {
            return await applicationDbContext.Skills
                .AsNoTracking()
                .OrderBy(s => s.Id)
                .ToListAsync();
        }
    }
}
