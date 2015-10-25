namespace SocialNetwork.ConsoleClient.XmlMapping
{
    using System;
    using System.Xml.Serialization;

    /// <remarks />
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Friendships
    {
        /// <remarks />
        [XmlElement("Friendship")]
        public FriendshipsFriendship[] Friendship { get; set; }
    }

    /// <remarks />
    [XmlType(AnonymousType = true)]
    public class FriendshipsFriendship
    {
        /// <remarks />
        [XmlElement(IsNullable = true)]
        public string FriendsSince { get; set; }

        /// <remarks />
        public FriendshipsFriendshipFirstUser FirstUser { get; set; }

        /// <remarks />
        public FriendshipsFriendshipSecondUser SecondUser { get; set; }

        /// <remarks />
        [XmlArrayItem("Message", IsNullable = false)]
        public FriendshipsFriendshipMessage[] Messages { get; set; }

        /// <remarks />
        [XmlAttribute]
        public bool Approved { get; set; }
    }

    /// <remarks />
    [XmlType(AnonymousType = true)]
    public class FriendshipsFriendshipFirstUser
    {
        /// <remarks />
        public string Username { get; set; }

        /// <remarks />
        public string FirstName { get; set; }

        /// <remarks />
        public string LastName { get; set; }

        /// <remarks />
        public DateTime RegisteredOn { get; set; }

        /// <remarks />
        [XmlArrayItem("Image", IsNullable = false)]
        public FriendshipsFriendshipFirstUserImage[] Images { get; set; }
    }

    /// <remarks />
    [XmlType(AnonymousType = true)]
    public class FriendshipsFriendshipFirstUserImage
    {
        /// <remarks />
        public string ImageUrl { get; set; }

        /// <remarks />
        public string FileExtension { get; set; }
    }

    /// <remarks />
    [XmlType(AnonymousType = true)]
    public class FriendshipsFriendshipSecondUser
    {
        /// <remarks />
        public string Username { get; set; }

        /// <remarks />
        public string FirstName { get; set; }

        /// <remarks />
        public string LastName { get; set; }

        /// <remarks />
        public DateTime RegisteredOn { get; set; }

        /// <remarks />
        [XmlArrayItem("Image", IsNullable = false)]
        public FriendshipsFriendshipSecondUserImage[] Images { get; set; }
    }

    /// <remarks />
    [XmlType(AnonymousType = true)]
    public class FriendshipsFriendshipSecondUserImage
    {
        /// <remarks />
        public string ImageUrl { get; set; }

        /// <remarks />
        public string FileExtension { get; set; }
    }

    /// <remarks />
    [XmlType(AnonymousType = true)]
    public class FriendshipsFriendshipMessage
    {
        /// <remarks />
        public string Author { get; set; }

        /// <remarks />
        public string Content { get; set; }

        /// <remarks />
        public DateTime SentOn { get; set; }

        /// <remarks />
        [XmlElement(IsNullable = true)]
        public DateTime SeenOn { get; set; }
    }
}