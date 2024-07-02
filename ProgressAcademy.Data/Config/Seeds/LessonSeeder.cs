using MongoDB.Driver;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.ReadModels;

namespace ProgressAcademy.Data.Config.Seeds
{
    /// <summary>
    /// Class for seeding the Lesson collection with initial data.
    /// </summary>
    public class LessonSeeder : DataSeeder
    {
        private const string collectionName = "lessons";

        /// <summary>
        /// Initializes a new instance of the <see cref="LessonSeeder"/> class.
        /// </summary>
        /// <param name="database">An instance of <see cref="IMongoDatabase"/> representing the MongoDB database.</param>
        public LessonSeeder(IMongoDatabase database) : base(database) => CreateCollectionIfNotExist(collectionName);

        /// <summary>
        /// Seeds the Lesson collection with initial data.
        /// </summary>
        public override async Task SeedDataAsync()
        {
            var collection = _database.GetCollection<Lesson>(collectionName);
            if (await collection.EstimatedDocumentCountAsync() == 0)
            {
                var lessons = new List<Lesson>
                {
                    new Lesson {
                        Title = "Introduction to Programming",
                        MeetingNotes = "Today we covered basic concepts of programming.",
                        ComplitionPercentage = 90,
                        Themes = new List<SimplifiedTheme>
                        {
                            new SimplifiedTheme { Title = "ASP.NET Core" }
                        }
                    },
                    new Lesson {
                        Title = "Data Structures and Algorithms",
                        MeetingNotes = "We discussed various data structures and algorithms.",
                        ComplitionPercentage = 85,
                        Themes = new List<SimplifiedTheme>()
                    }
                };
                await collection.InsertManyAsync(lessons);
            }
        }
    }
}