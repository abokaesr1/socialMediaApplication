
using Microsoft.EntityFrameworkCore;
using SocialMediaDatabase.Data.Models;

namespace SocialMediaDatabase.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }

    }
}