using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaDatabase.Data.Models
{
    public class Post
    {
        [Key]
        public int postId{ get; set; }
       
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }

        public int NrOfReports{ get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? publishAt { get; set; }


    }
}