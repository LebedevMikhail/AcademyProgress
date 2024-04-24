using MediatR;

namespace ProgressAcademy.Application.Queries.Lesson;

/// <summary>
/// Represents a query used to retrieve a lesson by its unique identifier.
/// </summary>
public class GetLessonByIdQuery : IRequest<Domain.Models.Lesson>
{
    /// <summary>
    /// Gets or sets the unique identifier of the lesson to retrieve.
    /// </summary>
    public int LessonId { get; set; }
}
