using Linkup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linkup.Services.Interfaces
{
    public interface IProjectService
    {
        Task Create(Project project);
        Task Update(int id, Project project);
        Task<List<Project>> GetAll();
        Task<Project> GetById(int id);
    }
}
