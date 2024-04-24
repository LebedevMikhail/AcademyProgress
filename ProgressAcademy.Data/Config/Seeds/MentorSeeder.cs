using MongoDB.Driver;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.ReadModels;

namespace ProgressAcademy.Data.Config
{
    /// <summary>
    /// Class for seeding mentor data.
    /// </summary>
    public class MentorSeeder : IDataSeeder
    {
        private readonly IMongoCollection<Mentor> _mentorCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MentorSeeder"/> class.
        /// </summary>
        /// <param name="mentorCollection">The MongoDB collection for mentor data.</param>
        public MentorSeeder(IMongoCollection<Mentor> mentorCollection)
        {
            _mentorCollection = mentorCollection;
        }

        /// <summary>
        /// Method for seeding mentor data.
        /// </summary>
        public void SeedData()
        {
            var mentors = GenerateMentors(50); // Generate 50 mentor entities
            _mentorCollection.InsertMany(mentors); // Insert mentor data into the collection
        }

        /// <summary>
        /// Generates a list of mentor entities.
        /// </summary>
        /// <param name="count">The number of mentors to generate.</param>
        /// <returns>A list of mentor entities.</returns>
        private List<Mentor> GenerateMentors(int count)
        {
            var mentors = new List<Mentor>();

            for (int i = 0; i < count; i++)
            {
                mentors.Add(new Mentor { FullName = $"Mentor {i + 1}", Mentees = new List<SimplifiedMentee>() });
            }

            return mentors;
        }
    }
}