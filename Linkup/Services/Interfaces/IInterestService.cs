using Linkup.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linkup.Services.Interfaces
{
    public interface IInterestService
    {
        Task Create(Interest interest);
        Task<List<Interest>> GetAll();
        Task<Interest> GetById(int id);
    }
}
