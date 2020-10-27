using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Linkup.Models;
using Linkup.Services.Interfaces;
using Linkup.ViewModels.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Linkup.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;
        private readonly ISkillService skillService;
        private readonly IInterestService interestService;
        private readonly IApplicationUserService applicationUserService;

        public ProjectController(IProjectService projectService,
            ISkillService skillService,
            IInterestService interestService,
            IApplicationUserService applicationUserService)
        {
            this.projectService = projectService;
            this.skillService = skillService;
            this.interestService = interestService;
            this.applicationUserService = applicationUserService;
        }

        [HttpGet]
        public async Task<IActionResult> Initiatives(string filter)
        {
            List<Project> projects = new List<Project>();

            if (string.IsNullOrEmpty(filter))
                projects = await projectService.GetAll();
            else if (filter.ToUpper() == "NEW")
                projects = await projectService.GetNew();
            else if(filter.ToUpper() == "COMPLETED")
                projects = await projectService.GetCompleted();
            else if(filter.ToUpper() == "RECRUITING")
                projects = await projectService.GetRecruting();
            else if(filter.ToUpper() == "INPROGRESS")
                projects = await projectService.GetInProgress();
            else if (filter.ToUpper() == "MY")
                projects = await projectService.GetByOwner(User.Identity.Name);

            var model = new ProjectListViewModel
            {
                Projects = new List<ProjectViewModel>()
            };

            foreach (var item in projects)
            {
                var createdBy = await applicationUserService.GetByEmail(item.CreatedBy);
                var project = new ProjectViewModel
                {
                    ProjectId = item.Id,
                    CreatedBy = $"{createdBy.FirstName} {createdBy.LastName}",
                    Description = item.Description,
                    Title = item.Title,
                    DueDate = item.DueDate,
                    Progress = item.Progress,
                    Status = item.Status,
                    NeededSkills = item.NeededSkills.Count
                };

                model.Projects.Add(project);
            }

            return View(model);
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
                CreatedBy = User.Identity.Name,

            };
            await projectService.Create(project);
            await applicationUserService.AddUserProject(User.Identity.Name, project.Id);
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
