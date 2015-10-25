namespace SocialNetwork.ConsoleClient
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    using Data;

    using Models;

    using XmlMapping;

    public class Startup
    {
        public static void Main()
        {
            ImportDataFromFriendshipsXml();
            ImportDataFromPostsXml();
        }

        private static void ImportDataFromPostsXml()
        {
            var postsAsString =
                Directory.GetFiles(Directory.GetCurrentDirectory() + "/XmlFiles/")
                         .Where(file => file.Contains("Posts") && file.EndsWith(".xml"))
                         .Select(File.ReadAllText)
                         .FirstOrDefault();

            var stringReader = new StringReader(postsAsString);
            var xmlSerializer = (Posts)new XmlSerializer(typeof(Posts)).Deserialize(stringReader);
            foreach (var post in xmlSerializer.Post)
            {
                var db = new SocialNetworkDbContext();

                var dbUsers = post.Users;

                var dbPost = new Post { PostContent = post.Content, PostDate = post.PostedOn };

                db.Posts.Add(dbPost);
                db.SaveChanges();
            }
        }

        private static void ImportDataFromFriendshipsXml()
        {
            var friendshipsAsString =
                Directory.GetFiles(Directory.GetCurrentDirectory() + "/XmlFiles/")
                         .Where(file => file.Contains("Friendship") && file.EndsWith(".xml"))
                         .Select(File.ReadAllText)
                         .FirstOrDefault();

            var stringReader = new StringReader(friendshipsAsString);
            var xmlSerializer = (Friendships)new XmlSerializer(typeof(Friendships)).Deserialize(stringReader);
            foreach (var friendship in xmlSerializer.Friendship)
            {
                var db = new SocialNetworkDbContext();

                var dbMessages =
                    friendship.Messages.Select(
                        friendshipMessage =>
                        new Message
                            {
                                Author = friendshipMessage.Author,
                                Content = friendshipMessage.Content,
                                SentOn = friendshipMessage.SentOn,
                                SeenOn = friendshipMessage.SeenOn
                            }).ToList();

                var dbFriendship = new Friendship
                    {
                        FirstUser =
                            new User
                                {
                                    Username = friendship.FirstUser.Username,
                                    FirstName = friendship.FirstUser.FirstName,
                                    LastName = friendship.FirstUser.LastName
                                },
                        SecondUser =
                            new User
                                {
                                    Username = friendship.SecondUser.Username,
                                    FirstName = friendship.SecondUser.FirstName,
                                    LastName = friendship.SecondUser.LastName
                                },
                        FriendsSince = DateTime.Parse(friendship.FriendsSince),
                        IsApproved = friendship.Approved,
                        Messages = dbMessages
                    };

                db.Friendships.Add(dbFriendship);
                db.SaveChanges();
            }
        }
    }
}