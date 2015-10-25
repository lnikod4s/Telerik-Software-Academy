namespace SocialNetwork.ConsoleClient.XmlMapping
{
    using System;
    using System.Xml.Serialization;

    /// <remarks />
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Posts
    {
        /// <remarks />
        [XmlElement("Post")]
        public PostsPost[] Post { get; set; }
    }

    /// <remarks />
    [XmlType(AnonymousType = true)]
    public class PostsPost
    {
        /// <remarks />
        public string Content { get; set; }

        /// <remarks />
        public DateTime PostedOn { get; set; }

        /// <remarks />
        public string Users { get; set; }
    }
}