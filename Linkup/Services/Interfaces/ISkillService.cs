using Linkup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linkup.Services.Interfaces
{
    public interface ISkillService
    {
        Task Create(Skill skill);
        Task<List<Skill>> GetAll();
        Task<Skill> GetById(int id);
    }
}
