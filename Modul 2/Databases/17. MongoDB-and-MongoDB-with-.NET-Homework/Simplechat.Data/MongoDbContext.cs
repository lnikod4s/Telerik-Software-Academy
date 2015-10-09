namespace Simplechat.Data
{
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class MongoDbContext
    {
        private readonly string connectionString;
        private readonly string databaseName;

        public MongoDbContext()
            : this(ConnectionStrings.Default.MongoDbLocalServer, ConnectionStrings.Default.MongoDbDefault)
        {
        }

        public MongoDbContext(string connectionString, string databaseName)
        {
            this.connectionString = connectionString;
            this.databaseName = databaseName;
        }

        public IMongoCollection<BsonDocument> Messages =>
            this.GetDatabase().GetCollection<BsonDocument>("Messages");

        public IMongoCollection<BsonDocument> Users =>
            this.GetDatabase().GetCollection<BsonDocument>("Users");

        private IMongoDatabase GetDatabase()
        {
            var mongoClient = new MongoClient(this.connectionString);
            var db = mongoClient.GetDatabase(this.databaseName);
            return db;
        }
    }
}