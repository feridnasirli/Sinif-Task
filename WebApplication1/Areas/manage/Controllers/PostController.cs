using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Composition;
using WebApplication1.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Areas.manage.Controllers
{
    [Area("manage")]
    public class PostController : Controller
    {
        private readonly ContextDb _contextDb;
        private readonly IWebHostEnvironment _web;

        public PostController(ContextDb contextDb,IWebHostEnvironment web)
        {
            _contextDb = contextDb;
            _web = web;
        }
        public IActionResult Index()
        {
           List<Post> posts = _contextDb.Posts.ToList();
            return View(posts);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Post post)
        {
            if(post.ImageFile.ContentType!= "image/png" && post.ImageFile.ContentType!="image/jpeg")
            {
                ModelState.AddModelError("ImageFile", "Only Jpeg and Png");
                return View();
            }
            post.Image = FileManager.SaveFile(_web.WebRootPath, "uploads/posts", post.ImageFile);
            _contextDb.Posts.Add(post);
            _contextDb.SaveChanges();

            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Post post = _contextDb.Posts.Find(id);
            if (post == null) return NotFound();
            return View(post);
        }
        [HttpPost]
        public IActionResult Update(Post post)
        {
            Post expost = _contextDb.Posts.FirstOrDefault(x => x.Id == post.Id);
            if(post==null)
            {
                return NotFound();
            }
            if (post.ImageFile != null)
            {
                if (post.ImageFile.ContentType != "image/png" && post.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Only Jpeg and Png");
                    return View();
                }

                string name = FileManager.SaveFile(_web.WebRootPath, "uploads/posts", post.ImageFile);
                FileManager.DeleteFile(_web.WebRootPath, "uploads/posts", expost.Image);

                expost.Image = name;
            }
            expost.Description = post.Description;
            expost.Title = post.Title;
            expost.REdirectUrl = post.REdirectUrl;

            _contextDb.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Post post = _contextDb.Posts.FirstOrDefault(x => x.Id == id);
            if (post == null) return NotFound();

            if (post.Image != null)
            {
                FileManager.DeleteFile(_web.WebRootPath, "uploads/posts", post.Image);

            }
            _contextDb.Remove(post);
            _contextDb.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
