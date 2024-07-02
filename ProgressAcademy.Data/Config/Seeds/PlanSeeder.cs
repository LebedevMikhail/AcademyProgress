using MongoDB.Driver;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.ReadModels;

namespace ProgressAcademy.Data.Config.Seeds
{
    /// <summary>
    /// Class for seeding the Plan collection with initial data.
    /// </summary>
    public class PlanSeeder : DataSeeder
    {
        private const string collectionName = "plans";

        /// <summary>
        /// Initializes a new instance of the <see cref="PlanSeeder"/> class.
        /// </summary>
        /// <param name="database">An instance of <see cref="IMongoDatabase"/> representing the MongoDB database.</param>
        public PlanSeeder(IMongoDatabase database) : base(database) => CreateCollectionIfNotExist(collectionName);

        /// <summary>
        /// Seeds the Plan collection with initial data.
        /// </summary>
        public override async Task SeedDataAsync()
        {
            var collection = _database.GetCollection<Plan>(collectionName);
            if (await collection.EstimatedDocumentCountAsync() == 0)
            {
                var plans = new List<Plan>
                {
                    new Plan
                    {
                        Title = "Learning Path for .NET Junior Developers",
                        Description = "This education plan covers the fundamental concepts of .NET development for junior developers.",
                        Lessons = new List<SimplifiedLesson>()
                    }
                };
                await collection.InsertManyAsync(plans);
            }
        }
    }
}