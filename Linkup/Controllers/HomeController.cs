using Linkup.Models;
using Linkup.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Linkup.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicationUserService applicationUserService;

        public HomeController(IApplicationUserService applicationUserService)
        {
            this.applicationUserService = applicationUserService;
        }

        public async Task<IActionResult> Index()
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
