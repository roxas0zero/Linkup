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
                .Include(p => p.NeededSkills)
                .AsNoTracking()                
                .OrderBy(s => s.Id)
                .ToListAsync();
        }

        public async Task<Project> GetById(int id)
        {
            return await applicationDbContext.Projects
                .Include(p => p.NeededSkills)
                .Include(p => p.RelatedInterests)
                .Include(p => p.Participants)
               .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddProjectSkill(int projectId, int skillId)
        {
            var project = await applicationDbContext.Projects
                .Include(p => p.NeededSkills)
                .Where(p => p.Id == projectId)
                .FirstOrDefaultAsync();
            var skill = await applicationDbContext.Skills.FindAsync(skillId);
            project.NeededSkills.Add(skill);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteProjectSkill(int projectId, int skillId)
        {
            var project = await applicationDbContext.Projects
                .Include(p => p.NeededSkills)
                .Where(p => p.Id == projectId)
                .FirstOrDefaultAsync();
            var skill = await applicationDbContext.Skills.FindAsync(skillId);
            project.NeededSkills.Remove(skill);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task AddProjectInterest(int projectId, int interestId)
        {
            var project = await applicationDbContext.Projects
                .Include(p => p.RelatedInterests)
                .Where(p => p.Id == projectId)
                .FirstOrDefaultAsync();
            var interest = await applicationDbContext.Interests.FindAsync(interestId);
            project.RelatedInterests.Add(interest);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteProjectInterest(int projectId, int interestId)
        {
            var project = await applicationDbContext.Projects
                .Include(p => p.RelatedInterests)
                .Where(p => p.Id == projectId)
                .FirstOrDefaultAsync();
            var interest = await applicationDbContext.Interests.FindAsync(interestId);
            project.RelatedInterests.Remove(interest);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<Project>> GetNew()
        {
            return await applicationDbContext.Projects
                .Include(p => p.NeededSkills)
                .AsNoTracking()
                .Where(p => p.Status == Enums.Status.Initialization)
                .OrderBy(s => s.Id)
                .ToListAsync();
        }

        public async Task<List<Project>> GetCompleted()
        {
            return await applicationDbContext.Projects
                .Include(p => p.NeededSkills)
                .AsNoTracking()
                .Where(p => p.Status == Enums.Status.Completed)
                .OrderBy(s => s.Id)
                .ToListAsync();
        }

        public async Task<List<Project>> GetRecruting()
        {
            return await applicationDbContext.Projects
                .Include(p => p.NeededSkills)
                .AsNoTracking()
                .Where(p => p.Status == Enums.Status.TeamBuilding)
                .OrderBy(s => s.Id)
                .ToListAsync();
        }

        public async Task<List<Project>> GetInProgress()
        {
            return await applicationDbContext.Projects
                .Include(p => p.NeededSkills)
                .AsNoTracking()
                .Where(p => p.Status == Enums.Status.Execution)
                .OrderBy(s => s.Id)
                .ToListAsync();
        }

        public async Task<List<Project>> GetByOwner(string email)
        {
            return await applicationDbContext.Projects
                .Include(p => p.NeededSkills)
                .AsNoTracking()
                .Where(p => p.CreatedBy == email)
                .OrderBy(s => s.Id)
                .ToListAsync();
        }
    }
}
