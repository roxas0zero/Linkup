using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Linkup.Models;
using Linkup.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Linkup.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IApplicationUserService applicationUserService;

        public ProfileController(IApplicationUserService applicationUserService)
        {
            this.applicationUserService = applicationUserService;
        }

        [HttpGet]
        public async Task<IActionResult> General()
        {
            var user = await applicationUserService.GetByEmail(User.Identity.Name);

            if (user == null)
            {
                var newUser = new ApplicationUser
                {
                    Email = User.Identity.Name,
                    FirstName = User.FindFirst(ClaimTypes.GivenName).Value,
                    LastName = User.FindFirst(ClaimTypes.Surname).Value
                };

                await applicationUserService.Create(newUser);                
            }

            return View();
        }
    }
}
