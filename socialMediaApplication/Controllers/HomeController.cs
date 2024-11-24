using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaDatabase.Data;
using System.Diagnostics;
using socialMediaApplication.ViewModels.Home;
using SocialMediaDatabase.Models;

namespace socialMediaApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationContext _context;

        public HomeController(ILogger<HomeController> logger ,ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allPosts = await _context.Posts
            .Include(n=>n.User)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();

            return View(allPosts);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostVM post)
        {
            int userId = 1;
            var newPost = new Post
            {
                Description = post.Content,
                ImageUrl = "",
                UserId = userId,
                NrOfReports = 0,
                CreatedAt = DateTime.Now,
                PublishAt = DateTime.Now
            };

             _context.Posts.Add(newPost);
            await _context.SaveChangesAsync();
            // redicrection to home page
            return RedirectToAction("Index");
        }

       
    }
}
