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
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ApplicationDbContext applicationDbContext;        

        public ApplicationUserService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task Create(ApplicationUser applicationUser)
        {
            applicationDbContext.Add(applicationUser);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task Update(ApplicationUser applicationUser)
        {
            applicationDbContext.Update(applicationUser);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<ApplicationUser> GetByEmail(string email)
        {
            return await applicationDbContext.ApplicationUsers
                .AsNoTracking()
                .Include(u => u.Skills)
                .Include(u => u.Interests)
                .Include(u => u.Projects)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            return await applicationDbContext.ApplicationUsers
                .AsNoTracking()
                .OrderBy(a => a.Email)
                .ToListAsync();
        }

        public async Task<bool> Exists(string email)
        {
            return await applicationDbContext.ApplicationUsers
                .AsNoTracking()
                .AnyAsync(e => e.Email == email);
        }

        public async Task AddUserSkill(string email, int skillId)
        {
            var user = await applicationDbContext.ApplicationUsers
                .Include(u => u.Skills)
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync();
            var skill = await applicationDbContext.Skills.FindAsync(skillId);
            user.Skills.Add(skill);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteUserSkill(string email, int skillId)
        {
            var user = await applicationDbContext.ApplicationUsers
                .Include(u => u.Skills)
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync();
            var skill = await applicationDbContext.Skills.FindAsync(skillId);
            user.Skills.Remove(skill);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task AddUserInterest(string email, int interestId)
        {
            var user = await applicationDbContext.ApplicationUsers
                 .Include(u => u.Interests)
                 .Where(u => u.Email == email)
                 .FirstOrDefaultAsync();
            var interest = await applicationDbContext.Interests.FindAsync(interestId);
            user.Interests.Add(interest);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteUserInterest(string email, int interestId)
        {
            var user = await applicationDbContext.ApplicationUsers
                .Include(u => u.Interests)
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync();
            var interest = await applicationDbContext.Interests.FindAsync(interestId);
            user.Interests.Remove(interest);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}
