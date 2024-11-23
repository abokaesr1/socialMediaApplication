using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaDatabase.Models
{
    public class Post
    {
        [Key]
        public int postId{ get; set; }
       
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public int NrOfReports{ get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? PublishAt { get; set; }

        // forging Key
        public int UserId { get; set; }

        // Navigation Property
        public User User { get; set; }

    }
}