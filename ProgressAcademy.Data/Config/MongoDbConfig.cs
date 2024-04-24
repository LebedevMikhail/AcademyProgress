using MongoDB.Driver;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.ReadModels;

namespace ProgressAcademy.Data.Config;

/// <summary>
    /// Class for configuring MongoDB database.
    /// </summary>
    public class MongoDbConfig
    {
        private readonly List<IDataSeeder> _seeders; // Array of seeders for data seeding

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbConfig"/> class.
        /// </summary>
        /// <param name="seeders">The data seeders to be used.</param>
        public MongoDbConfig(params IDataSeeder[] seeders)
        {
            _seeders = seeders; // Initialize the array of seeders
        }

        /// <summary>
        /// Method for seeding all data.
        /// </summary>
        public void SeedData()
        {
            foreach (var seeder in _seeders) // Iterate through all seeders
            {
                seeder.SeedData(); // Seed data using the current seeder
            }
        }
    }

    private List<Mentee> SeedMentees()
    {

        return new List<Mentee>
            {
                new() { FullName = "John Doe", Plans = new List<Plan>() },
                new() { FullName = "Jane Doe", Plans = new List<Plan>() }
            };

    }

    private void SeedMentors()
    {
        var mentorCollection = _database.GetCollection<Mentor>("mentors");

        var mentors = new List<Mentor>
            {
                new() { FullName = "Michael Smith", Mentees = new List<SimplifiedMentee>() },
                new() { FullName = "Emily Johnson", Mentees = new List<SimplifiedMentee>() }
            };

        mentorCollection.InsertMany(mentors);
    }

    private void SeedLessons()
    {
        var lessonCollection = _database.GetCollection<Lesson>("lessons");

        var lessons = new List<Lesson>
            {
                new() {
                    Title = "Introduction to Programming",
                     MeetingNotes = "Today we covered basic concepts of programming.",
                    ComplitionPercentage = 90,
                    Themes = new List<SimplifiedTheme>()
                    {
                        new () {
                            Title = "ASP.NET Core",
                }
                }
                },
                new() { Title = "Data Structures and Algorithms", MeetingNotes = "We discussed various data structures and algorithms.", ComplitionPercentage = 85, Themes = new List<SimplifiedTheme>() }
            };

        lessonCollection.InsertMany(lessons);
    }

    public void SeedThemes()
    {
        // Generate themes for .NET junior developers
        List<Theme> themes = new List<Theme>
            {
                new Theme
                {
                    Title = ".NET Basics",
                    Questions = new List<IQuestionAnswer>
                    {
                        new MultipleChoiceQuestion
                        {
                            Question = "What is the CLR?",
                            Options = new List<string> {"A. Common Language Runtime", "B. Common Library Repository", "C. Common Language Repository"},
                            Answers = new List<string>{ "A" }
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
                            Options = new List<string> {"A. A web framework", "B. A programming language", "C. A database management system"},
                            Answers = new List<string>{ "A" }
                        },
                        new FreeFormQuestion
                        {
                            Question = "Explain the concept of middleware in ASP.NET Core."
                        }
                    }
                },
            };
    }

    public void SeedPlans()
    {
        // Generate education plans for .NET junior developers
        List<Plan> plans = new List<Plan>
            {
                new Plan
                {
                    Title = "Learning Path for .NET Junior Developers",
                    Description = "This education plan covers the fundamental concepts of .NET development for junior developers.",
                    Lessons = new List<SimplifiedLesson>
                    {
                    }
                }
            };
    }
}