using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContextDb _contextDb;

        public HomeController(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }
        public IActionResult Index()
        {
           var posts = _contextDb.Posts.ToList();
            return View(posts);
        }
    }
}