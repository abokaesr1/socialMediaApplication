using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaDatabase.Data;
using System.Diagnostics;
using socialMediaApplication.ViewModels.Home;

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
            var allPosts = await _context.Posts.Include(n=>n.User).ToListAsync();

            return View(allPosts);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostVM post)
        {
            int userId = 1;
            var newPost = new Post{
                Description = post.Description,
                ImageUrl = "",
                UserId = userId,
                NrOfReports = 0
                CreatedAt = DateTime.utcNow,
                PublishAt = DateTime.utcNow
            }

            await _context.Posts.Add(newPost);
            await _context.SaveChangesAsync();

            // redicrection to home page
            return RedirectToAction("Index");
        }

       
    }
}
