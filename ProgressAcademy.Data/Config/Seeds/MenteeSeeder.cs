using MongoDB.Driver;
using ProgressAcademy.Domain.Models;

namespace ProgressAcademy.Data.Config.Seeds;

/// <summary>
    /// Class for seeding mentee data.
    /// </summary>
    public class MenteeSeeder : IDataSeeder
    {
        private readonly IMongoCollection<Mentee> _menteeCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenteeSeeder"/> class.
        /// </summary>
        /// <param name="menteeCollection">The MongoDB collection for mentee data.</param>
        public MenteeSeeder(IMongoCollection<Mentee> menteeCollection)
        {
            _menteeCollection = menteeCollection;
        }

        /// <summary>
        /// Method for seeding mentee data.
        /// </summary>
        public void SeedData()
        {
            var mentees = GenerateMentees(50); // Generate 50 mentee entities
            _menteeCollection.InsertMany(mentees); // Insert mentee data into the collection
        }

        /// <summary>
        /// Generates a list of mentee entities.
        /// </summary>
        /// <param name="count">The number of mentees to generate.</param>
        /// <returns>A list of mentee entities.</returns>
        private List<Mentee> GenerateMentees(int count)
        {
            var mentees = new List<Mentee>();

            for (int i = 0; i < count; i++)
            {
                mentees.Add(new Mentee { FullName = $"Mentee {i + 1}", Plans = new List<Plan>() });
            }

            return mentees;
        }
    }