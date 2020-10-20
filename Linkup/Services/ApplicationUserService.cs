﻿using Linkup.Data;
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

        public async Task Update(string corpId, ApplicationUser applicationUser)
        {
            var applicationUserFromDb = await applicationDbContext.ApplicationUsers.FindAsync(corpId);

            if (applicationUserFromDb.CorpId == applicationUser.CorpId)
            {
                applicationUserFromDb.FirstName = applicationUser.FirstName;
                applicationUserFromDb.LastName = applicationUser.LastName;
                applicationUserFromDb.Email = applicationUser.Email;
                applicationUserFromDb.Mobile = applicationUser.Mobile;
                applicationUserFromDb.Skills = applicationUser.Skills;

                await applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<ApplicationUser> GetById(string corpId)
        {
            return await applicationDbContext.ApplicationUsers
                .FirstOrDefaultAsync(u => u.CorpId == corpId);
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            return await applicationDbContext.ApplicationUsers
                .AsNoTracking()
                .OrderBy(a => a.CorpId)
                .ToListAsync();
        }
    }
}