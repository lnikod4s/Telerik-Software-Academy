namespace Simplechat.Models
{
    using System;

    public class User
    {
        public string Name { get; set; }

        public DateTime LoginTime { get; set; }

        public ServerRole ServerRole { get; set; }
    }
}