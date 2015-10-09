namespace Simplechat.Models
{
    using System;

    public class Message
    {
        public string Text { get; set; }

        public DateTime PostDate { get; set; }

        public User PostUser { get; set; }
    }
}