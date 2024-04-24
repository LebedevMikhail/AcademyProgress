using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProgressAcademy.Domain.ReadModels;

namespace ProgressAcademy.Domain.Models;

/// <summary>
/// Represents an educational plan, detailing the structure and goals of a specific learning path or curriculum.
/// </summary>
public class Plan
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
    /// Gets or sets the title of the plan.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the grade level targeted by the plan.
    /// </summary>
    public string? Grade { get; set; }

    /// <summary>
    /// Gets or sets a detailed description of the plan.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the main task or objective that the plan aims to achieve.
    /// </summary>
    public string? Task { get; set; }

    /// <summary>
    /// Gets or sets the current progress made towards the plan's completion.
    /// </summary>
    public int CurrentProgress { get; set; }

    /// <summary>
    /// Gets or sets the list of lessons included in the plan.
    /// </summary>
    /// <remarks>
    /// This list provides a simplified overview of each lesson's content and objectives.
    /// </remarks>
    public List<SimplifiedLesson>? Lessons { get; set; }

    /// <summary>
    /// Gets or sets the start date of the plan.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Gets or sets the end date of the plan, indicating when the plan is expected to be completed.
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Gets or sets the overarching goal of the plan.
    /// </summary>
    public string? Goal { get; set; }
}
