using Linkup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linkup.Services.Interfaces
{
    public interface IActiveDirectoryService
    {
        ActiveDirectoryUser GetUserInfo(string corpId);
        string GetUserFirstName(string corpId);
    }
}
