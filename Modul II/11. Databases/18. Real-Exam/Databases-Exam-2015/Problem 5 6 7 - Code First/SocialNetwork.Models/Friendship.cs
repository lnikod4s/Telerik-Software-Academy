namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Friendship
    {
        private readonly ICollection<Message> messages;

        public Friendship()
        {
            this.messages = new HashSet<Message>();
        }

        public int FriendshipId { get; set; }

        public bool? IsApproved { get; set; }

        public DateTime FriendsSince { get; set; }

        public int FirstUserId { get; set; }

        [ForeignKey("FirstUserId")]
        public User FirstUser { get; set; }

        public int SecondUserId { get; set; }

        [ForeignKey("SecondUserId")]
        public User SecondUser { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}