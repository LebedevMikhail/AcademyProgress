using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProgressAcademy.Domain.Models
{
    /// <summary>
    /// Represents a free-form question.
    /// </summary>
    public class FreeFormQuestion : IQuestionAnswer
    {
        /// <summary>
        /// Gets or sets the unique identifier for the multiple choice answer.
        /// </summary>
        /// <remarks>
        /// The identifier is represented as an ObjectId in the MongoDB collection, ensuring uniqueness across documents.
        /// </remarks>
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }
        /// <summary>
        /// The question text.
        /// </summary>
        public string? Question { get; set; }

        /// <summary>
        /// The answer to the question.
        /// </summary>
        public List<string>? Answers { get; set; }
    }
}