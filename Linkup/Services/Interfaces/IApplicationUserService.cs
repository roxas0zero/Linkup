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
        Task Update(string corpId, ApplicationUser applicationUser);
        Task<ApplicationUser> GetById(string corpId);
        Task<List<ApplicationUser>> GetAll();
    }
}
