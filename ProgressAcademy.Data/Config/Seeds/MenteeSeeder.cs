using MongoDB.Driver;
using ProgressAcademy.Domain.Models;

namespace ProgressAcademy.Data.Config.Seeds
{
    /// <summary>
    /// Class for seeding the Mentee collection with initial data.
    /// </summary>
    public class MenteeSeeder : DataSeeder
    {
        private const string collectionName = "mentees";
        /// <summary>
        /// Initializes a new instance of the <see cref="MenteeSeeder"/> class.
        /// </summary>
        /// <param name="database">An instance of <see cref="IMongoDatabase"/> representing the MongoDB database.</param>
        public MenteeSeeder(IMongoDatabase database) : base(database) => CreateCollectionIfNotExist(collectionName);

        /// <summary>
        /// Seeds the Mentee collection with initial data.
        /// </summary>
        public override async Task SeedDataAsync()
        {
            var collection = _database.GetCollection<Mentee>(collectionName);
            if (await collection.EstimatedDocumentCountAsync() == 0)
            {
                var mentees = new List<Mentee>
                {
                    new Mentee { Id = 1, FullName = "John Doe", Plans = new List<Plan>() },
                    new Mentee { Id = 2, FullName = "Jane Smith", Plans = new List<Plan>() }
                };
                await collection.InsertManyAsync(mentees);
            }
        }

    }
}