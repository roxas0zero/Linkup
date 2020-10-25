using System.Threading.Tasks;
using Linkup.Models;
using Linkup.Services.Interfaces;
using Linkup.ViewModels.Project;
using Microsoft.AspNetCore.Mvc;

namespace Linkup.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
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
                DueDate = projectViewModel.DueDate
            };
            await projectService.Create(project);
            return RedirectToAction(nameof(AddDetails), new { Id = project.Id });
        }

        [HttpGet]
        public async Task<IActionResult> AddDetails(int id)
        {
            var project = await projectService.GetById(id);
            var model = new ProjectCreateViewModel
            {
                Title = project.Title,
                Description = project.Description,
                DueDate = project.DueDate
            };
            return View(model);
        }
    }
}
