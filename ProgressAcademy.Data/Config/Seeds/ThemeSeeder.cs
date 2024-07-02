using MongoDB.Driver;
using ProgressAcademy.Domain.Models;

namespace ProgressAcademy.Data.Config.Seeds
{
    /// <summary>
    /// Class for seeding the Theme collection with initial data.
    /// </summary>
    public class ThemeSeeder : DataSeeder
    {
        private const string collectionName = "themes";

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemeSeeder"/> class.
        /// </summary>
        /// <param name="database">An instance of <see cref="IMongoDatabase"/> representing the MongoDB database.</param>
        public ThemeSeeder(IMongoDatabase database) : base(database) => CreateCollectionIfNotExist(collectionName);

        /// <summary>
        /// Seeds the Theme collection with initial data.
        /// </summary>
        public override async Task SeedDataAsync()
        {
            var collection = _database.GetCollection<Theme>(collectionName);
            if (await collection.EstimatedDocumentCountAsync() == 0)
            {
                var themes = new List<Theme>
            {
                new Theme
                {
                    Title = ".NET Basics",
                    Questions = new List<IQuestionAnswer>
                    {
                        new MultipleChoiceQuestion
                        {
                            Question = "What is the CLR?",
                            Options = new List<string> { "A. Common Language Runtime", "B. Common Library Repository", "C. Common Language Repository" },
                            Answers = new List<string> { "A" }
                        },
                        new FreeFormQuestion
                        {
                            Question = "What is the difference between value types and reference types in C#?"
                        }
                    }
                },
                new Theme
                {
                    Title = "ASP.NET Core",
                    Questions = new List<IQuestionAnswer>
                    {
                        new MultipleChoiceQuestion
                        {
                            Question = "What is ASP.NET Core?",
                            Options = new List<string> { "A. A web framework", "B. A programming language", "C. A database management system" },
                            Answers = new List<string> { "A" }
                        },
                        new FreeFormQuestion
                        {
                            Question = "Explain the concept of middleware in ASP.NET Core."
                        }
                    }
                }
            };
                collection.InsertMany(themes);
            }
        }
    }
}