using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaDatabase.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Profile { get; set; }

        // Navigation Properties ( this present that the user has many posts)

        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}