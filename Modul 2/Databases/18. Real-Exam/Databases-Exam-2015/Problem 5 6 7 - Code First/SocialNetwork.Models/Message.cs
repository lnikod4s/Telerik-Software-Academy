namespace SocialNetwork.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Message
    {
        public int MessageId { get; set; }

        public int FriendshipId { get; set; }

        [ForeignKey("FriendshipId")]
        public Friendship Friendship { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public string Author { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime SentOn { get; set; }

        public DateTime SeenOn { get; set; }
    }
}