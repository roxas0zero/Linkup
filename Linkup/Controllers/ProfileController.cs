using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Linkup.Models;
using Linkup.Services.Interfaces;
using Linkup.ViewModels.Profile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Linkup.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IApplicationUserService applicationUserService;
        private readonly ISkillService skillService;
        private readonly IInterestService interestService;

        public ProfileController(IApplicationUserService applicationUserService,
            ISkillService skillService,
            IInterestService interestService)
        {
            this.applicationUserService = applicationUserService;
            this.skillService = skillService;
            this.interestService = interestService;
        }

        #region General

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

        #endregion

        #region Skills

        [HttpGet]
        public async Task<IActionResult> Skills()
        {
            var profile = await applicationUserService.GetByEmail(User.Identity.Name);
            var skills = await skillService.GetAll();
            var viewModel = new ProfileSkillsViewModel
            {
                CurrentSkills = profile.Skills.Select(s => new ProfileSkillViewModel
                {
                    Id = s.Id,
                    Skill = s.Name
                }).ToList(),
                Skills = skills.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                }).ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddSkill(int selectedSkill)
        {
            await applicationUserService.AddUserSkill(User.Identity.Name, selectedSkill);
            return RedirectToAction(nameof(Skills));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSkill(int selectedSkill)
        {
            await applicationUserService.DeleteUserSkill(User.Identity.Name, selectedSkill);
            return RedirectToAction(nameof(Skills));
        }

        #endregion

        #region Interests

        [HttpGet]
        public async Task<IActionResult> Interests()
        {
            var profile = await applicationUserService.GetByEmail(User.Identity.Name);
            var interests = await interestService.GetAll();
            var viewModel = new ProfileInterestsViewModel
            {
                CurrentInterests = profile.Interests.Select(i => new ProfileInterestViewModel
                {
                    Id = i.Id,
                    Interest = i.Name
                }).ToList(),
                Interests = interests.Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Name
                }).ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddInterest(int selectedInterest)
        {
            await applicationUserService.AddUserInterest(User.Identity.Name, selectedInterest);
            return RedirectToAction(nameof(Interests));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteInterest(int selectedInterest)
        {
            await applicationUserService.DeleteUserInterest(User.Identity.Name, selectedInterest);
            return RedirectToAction(nameof(Interests));
        }

        #endregion
    }
}
