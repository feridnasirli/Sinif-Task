using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.manage.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
