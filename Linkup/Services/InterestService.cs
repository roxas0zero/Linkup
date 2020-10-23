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
    public class InterestService : IInterestService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public InterestService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task Create(Interest interest)
        {
            applicationDbContext.Add(interest);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<Interest>> GetAll()
        {
            return await applicationDbContext.Interests
                .AsNoTracking()
                .OrderBy(s => s.Id)
                .ToListAsync();
        }

        public async Task<Interest> GetById(int id)
        {
            return await applicationDbContext.Interests
               .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
