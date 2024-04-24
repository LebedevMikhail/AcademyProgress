using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProgressAcademy.Domain.ReadModels;

namespace ProgressAcademy.Domain.Models;

/// <summary>
/// Represents a mentor or teacher within the educational platform, including their personal information and associated mentees.
/// </summary>
public class Mentor
{
    /// <summary>
    /// Gets or sets the unique identifier for the mentor.
    /// </summary>
    /// <remarks>
    /// The identifier is represented as an integer in the MongoDB collection.
    /// Note: Using integers as MongoDB document identifiers is not typical; ObjectId is commonly used.
    /// </remarks>
    [BsonId]
    [BsonRepresentation(BsonType.Int32)]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the full name of the mentor.
    /// </summary>
    public string? FullName { get; set; }

    /// <summary>
    /// Gets or sets the list of simplified mentee profiles associated with this mentor.
    /// </summary>
    /// <remarks>
    /// This list includes a simplified view of the mentees that are currently being mentored or have been mentored by this individual.
    /// </remarks>
    public List<SimplifiedMentee>? Mentees { get; set; }
}
