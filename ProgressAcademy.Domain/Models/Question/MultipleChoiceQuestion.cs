using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProgressAcademy.Domain.Models
{
    /// <summary>
    /// Represents a multiple-choice question.
    /// </summary>
    [BsonIgnoreExtraElements]
    public class MultipleChoiceQuestion : IQuestionAnswer
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
        [BsonElement("question")]
        public string? Question { get; set; }

        /// <summary>
        /// The list of options for the question.
        /// </summary>
        [BsonElement("options")]
        public List<string>? Options { get; set; }

        /// <summary>
        /// The selected answer for the question.
        /// </summary>
        [BsonElement("answers")]

        public List<string>? Answers { get; set; }
    }
}
