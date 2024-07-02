using MongoDB.Driver;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.ReadModels;

namespace ProgressAcademy.Data.Config.Seeds
{
    /// <summary>
    /// Class for seeding the Mentor collection with initial data.
    /// </summary>
    public class MentorSeeder : DataSeeder
    {
        private const string collectionName = "mentors";

        /// <summary>
        /// Initializes a new instance of the <see cref="MentorSeeder"/> class.
        /// </summary>
        /// <param name="database">An instance of <see cref="IMongoDatabase"/> representing the MongoDB database.</param>
        public MentorSeeder(IMongoDatabase database) : base(database) => CreateCollectionIfNotExist(collectionName);

        /// <summary>
        /// Seeds the Mentor collection with initial data.
        /// </summary>
        public override async Task SeedDataAsync()
        {
            var collection = _database.GetCollection<Mentor>(collectionName);
            if (await collection.EstimatedDocumentCountAsync() == 0)
            {
                var mentors = new List<Mentor>
                {
                    new Mentor { Id = 1, FullName = "Michael Smith", Mentees = new List<SimplifiedMentee>() },
                    new Mentor { Id = 2, FullName = "Emily Johnson", Mentees = new List<SimplifiedMentee>() }
                };
                await collection.InsertManyAsync(mentors);
            }
        }
    }
}