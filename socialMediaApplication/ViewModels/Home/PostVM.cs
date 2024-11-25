using System;


namespace socialMediaApplication.ViewModels.Home
{
    public class PostVM
    {
        public string? Content { get; set; }
        public IFormFile? ImageUrl { get; set; }
    }
}