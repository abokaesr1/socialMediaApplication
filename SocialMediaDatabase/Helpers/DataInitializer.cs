
using SocialMediaDatabase.Data;
using SocialMediaDatabase.Models;

namespace SocialMediaDatabase.Data.Helpers
{
    public static class DataInitializer
    {
        public static async Task SeedAsync (ApplicationContext applicationContext){
            if (!applicationContext.Users.Any() && !applicationContext.Posts.Any()){
                var newUsers = new User()
                {
                    FullName = "Mohammad Salamat",
                    Profile = "https://placehold.co/400"
                };
                await applicationContext.Users.AddAsync(newUsers);
                await applicationContext.SaveChangesAsync();
                var newPostsWithImage = new Post()
                {
                    Description = "This is the first post in the Social Media Database.",
                    ImageUrl = "https://placehold.co/600x400",
                    NrOfReports = 0,
                    CreatedAt = DateTime.Now,
                    PublishAt = DateTime.Now,
                    UserId = newUsers.Id,
                };
                var newPostsWithoutImage = new Post()
                {
                    Description = "This is the first post in the Social Media Database.",
                    ImageUrl = "",
                    NrOfReports = 0,
                    CreatedAt = DateTime.Now,
                    PublishAt = DateTime.Now,
                    UserId = newUsers.Id,
                };
                await applicationContext.Posts.AddRangeAsync(newPostsWithImage,newPostsWithoutImage);
                await applicationContext.SaveChangesAsync();
           
            }
      
               
            }
    }
}