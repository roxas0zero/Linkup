using Linkup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linkup.Services.Interfaces
{
    public interface IApplicationUserService
    {
        Task Create(ApplicationUser applicationUser);        
        Task Update(ApplicationUser applicationUser);
        Task<ApplicationUser> GetByEmail(string email);
        Task<List<ApplicationUser>> GetAll();
        Task<bool> Exists(string email);
        Task AddUserSkill(string email, int skillId);
        Task DeleteUserSkill(string email, int skillId);
        Task AddUserInterest(string email, int interestId);
        Task DeleteUserInterest(string email, int interestId);
    }
}
