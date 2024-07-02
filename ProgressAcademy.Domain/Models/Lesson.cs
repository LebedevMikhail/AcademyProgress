using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProgressAcademy.Domain.ReadModels;

namespace ProgressAcademy.Domain.Models;

/// <summary>
/// Represents a lesson within the educational platform, including its content and associated themes.
/// </summary>
public class Lesson
{
    /// <summary>
    /// Gets or sets the unique identifier for the lesson.
    /// </summary>
    /// <remarks>
    /// The identifier is represented as an integer in the MongoDB collection.
    /// </remarks>
    [BsonId]
    [BsonRepresentation(BsonType.Int32)]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the lesson.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the meeting notes associated with the lesson.
    /// </summary>
    public string? MeetingNotes { get; set; }

    // TODO: percantage correct answers of theme

    /// <summary>
    /// Gets or sets the score of the lesson, which can be used to rate its quality or difficulty.
    /// </summary>
    public int ComplitionPercentage { get; set; }

    /// <summary>
    /// Gets or sets the list of themes covered in the lesson. Each theme is simplified to include essential information only.
    /// </summary>
    public List<SimplifiedTheme>? Themes { get; set; }
}
