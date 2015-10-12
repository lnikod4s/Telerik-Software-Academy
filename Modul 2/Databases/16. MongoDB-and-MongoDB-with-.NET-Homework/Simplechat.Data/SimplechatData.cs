namespace Simplechat.Data
{
    using Models;

    public class SimplechatData
    {
        private readonly MongoDbContext mongoDbContext;

        public SimplechatData() : this(new MongoDbContext())
        {
        }

        public SimplechatData(MongoDbContext mongoDbContext)
        {
            this.mongoDbContext = mongoDbContext;
        }

        public static string GenerateMessageAsString(Message message)
        {
            var prettyDate = message.PostDate.ToLocalTime().ToString("dd.MM.yyyy hh:mm");
            return $"[{prettyDate}] {message.Text} - posted by {message.PostUser.Name}";
        }
    }
}