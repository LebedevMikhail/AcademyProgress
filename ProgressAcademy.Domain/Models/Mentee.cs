using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProgressAcademy.Domain.Models;

/// <summary>
/// Represents a mentee or student within the educational platform, including their personal information and associated learning plans.
/// </summary>
public class Mentee
{
    /// <summary>
    /// Gets or sets the unique identifier for the mentee.
    /// </summary>
    /// <remarks>
    /// The identifier is represented as an ObjectId in the MongoDB collection, ensuring uniqueness across documents.
    /// </remarks>
    [BsonId]
    [BsonRepresentation(BsonType.Int32)]
    public int Id { get; set; } // Changed to string to match MongoDB ObjectId

    /// <summary>
    /// Gets or sets the full name of the mentee.
    /// </summary>
    public string? FullName { get; set; }

    /// <summary>
    /// Gets or sets the list of learning plans associated with the mentee.
    /// </summary>
    /// <remarks>
    /// This list includes all the plans that the mentee is currently enrolled in or has completed.
    /// </remarks>
    public List<Plan>? Plans { get; set; }
}
