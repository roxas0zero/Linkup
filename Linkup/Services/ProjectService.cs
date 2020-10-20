using Linkup.Data;
using Linkup.Models;
using Linkup.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linkup.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ProjectService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task Create(Project project)
        {
            applicationDbContext.Add(project);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task Update(int id, Project project)
        {
            var projectFromDb = await applicationDbContext.Projects.FindAsync(id);

            if (projectFromDb.Id == projectFromDb.Id)
            {
                projectFromDb.Title = projectFromDb.Title;
                projectFromDb.Status = projectFromDb.Status;
                projectFromDb.Progress = projectFromDb.Progress;
                projectFromDb.Participants = projectFromDb.Participants;
                projectFromDb.NeededSkills = projectFromDb.NeededSkills;
                await applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Project>> GetAll()
        {
            return await applicationDbContext.Projects
                .AsNoTracking()
                .OrderBy(s => s.Id)
                .ToListAsync();
        }

        public async Task<Project> GetById(int id)
        {
            return await applicationDbContext.Projects
               .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
