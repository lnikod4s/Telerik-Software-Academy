namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        private readonly ICollection<User> users;

        public Post()
        {
            this.users = new HashSet<User>();
        }

        public int PostId { get; set; }

        [Required]
        [MinLength(10)]
        public string PostContent { get; set; }

        public DateTime PostDate { get; set; }

        public ICollection<User> Users { get; set; }
    }
}