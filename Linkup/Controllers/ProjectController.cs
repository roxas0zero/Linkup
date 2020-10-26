using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Linkup.Models;
using Linkup.Services.Interfaces;
using Linkup.ViewModels.Profile;
using Linkup.ViewModels.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Linkup.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;
        private readonly ISkillService skillService;
        private readonly IInterestService interestService;

        public ProjectController(IProjectService projectService,
            ISkillService skillService,
            IInterestService interestService)
        {
            this.projectService = projectService;
            this.skillService = skillService;
            this.interestService = interestService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectCreateViewModel projectViewModel)
        {
            var project = new Project
            {
                Title = projectViewModel.Title,
                Description = projectViewModel.Description,
                DueDate = projectViewModel.DueDate,
                CreatedBy = User.Identity.Name
            };
            await projectService.Create(project);
            return RedirectToAction(nameof(AddDetails), new { Id = project.Id });
        }

        [HttpGet]
        public async Task<IActionResult> AddDetails(int id)
        {
            var project = await projectService.GetById(id);

            if (project.CreatedBy != User.Identity.Name)
            {
                return Forbid();
            }

            var skillsList = await skillService.GetAll();
            var interestsList = await interestService.GetAll();

            var model = new ProjectCreateViewModel
            {
                ProjectId = project.Id,
                Title = project.Title,
                Description = project.Description,
                DueDate = project.DueDate,
                CreatedBy = project.CreatedBy,
                SkillsList = skillsList.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                }).ToList(),
                NeededSkills = project.NeededSkills.Select(s => new ProjectSkillViewModel
                {
                    Id = s.Id,
                    Skill = s.Name
                }).ToList(),
                InterestList = interestsList.Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Name
                }).ToList(),
                RelatedInterests = project.RelatedInterests.Select(i => new ProjectInterestViewModel
                {
                    Id = i.Id,
                    Interest = i.Name
                }).ToList()
            };            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddSkill(int projectId, int selectedSkill)
        {
            await projectService.AddProjectSkill(projectId, selectedSkill);
            return RedirectToAction(nameof(AddDetails), new { Id = projectId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSkill(int projectId, int selectedSkill)
        {
            await projectService.DeleteProjectSkill(projectId, selectedSkill);
            return RedirectToAction(nameof(AddDetails), new { Id = projectId });
        }

        [HttpPost]
        public async Task<IActionResult> AddInterest(int projectId, int selectedInterest)
        {
            await projectService.AddProjectInterest(projectId, selectedInterest);
            return RedirectToAction(nameof(AddDetails), new { Id = projectId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteInterest(int projectId, int selectedInterest)
        {
            await projectService.DeleteProjectInterest(projectId, selectedInterest);
            return RedirectToAction(nameof(AddDetails), new { Id = projectId });
        }
    }
}
