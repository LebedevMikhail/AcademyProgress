using MongoDB.Driver;

namespace ProgressAcademy.Data.Config;
public class MongoDbConfig 
{
        private readonly IMongoDatabase _database;

        public MongoDbConfig(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoDatabase Database => _database;
    }
