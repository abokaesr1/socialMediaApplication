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

           // Handle image upload
            string imageUrlt = "";
           // Handle image upload
                if (post.ImageUrl != null && post.ImageUrl.Length > 0)
                {
                    // Generate a unique filename for the uploaded file
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(post.ImageUrl.FileName);
                    // Set the path to store the file in wwwroot/images
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                    // Ensure the "images" directory exists
                    string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);  // Create the directory if it doesn't exist
                    }
                    // Save the file
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await post.ImageUrl.CopyToAsync(stream);
                    }
                    // Set the image URL to store in the database (relative to the root)
                    imageUrlt = "/images/" + fileName;
                }
            int userId = 1;
            // save the image, check if it already exists
            var newPost = new Post
            {
                Description = post.Content,
                ImageUrl = imageUrlt,
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
