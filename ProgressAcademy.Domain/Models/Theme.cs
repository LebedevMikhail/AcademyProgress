using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProgressAcademy.Domain.Models
{
    /// <summary>
    /// Represents a theme containing questions.
    /// </summary>
    public class Theme
    {
        /// <summary>
        /// Gets or sets the unique identifier for the plan.
        /// </summary>
        /// <remarks>
        /// The identifier is represented as an integer in the MongoDB collection.
        /// </remarks>
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }
        
        /// <summary>
        /// The title of the theme.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// The list of questions associated with the theme.
        /// </summary>
        public List<IQuestionAnswer>? Questions { get; set; }
    }
}