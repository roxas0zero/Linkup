using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Linkup.Models;
using Linkup.Services.Interfaces;
using Linkup.ViewModels.Profile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var profile = await applicationUserService.GetByEmail(User.Identity.Name);
            var viewModel = new ProfileGeneralViewModel
            {
                Email = profile.Email,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Mobile = profile.Mobile,
                Department = profile.Department,
                Team = profile.Team,
                Extension = profile.Extension
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditGeneral()
        {
            var profile = await applicationUserService.GetByEmail(User.Identity.Name);
            var viewModel = new ProfileGeneralViewModel
            {
                Email = profile.Email,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Mobile = profile.Mobile,
                Department = profile.Department,
                Team = profile.Team,
                Extension = profile.Extension
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGeneral([Bind("Email,FirstName,LastName,Mobile,Department,Team,Extension")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                await applicationUserService.Update(applicationUser);
                return RedirectToAction(nameof(General));
            }
            return RedirectToAction(nameof(EditGeneral));
        }
    }
}
