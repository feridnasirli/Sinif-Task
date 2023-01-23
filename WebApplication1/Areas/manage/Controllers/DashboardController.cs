using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Areas.manage.Controllers
{
    [Area("manage")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreateAdmin()
        {
            AppUser user = new AppUser
            {
                FullName = "Ferid Nesilri",
                UserName = "SuperAdmin"
            };
            return Ok("Created");
        }
    }
}
