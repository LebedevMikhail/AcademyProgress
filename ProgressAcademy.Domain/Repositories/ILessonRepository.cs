using ProgressAcademy.Domain.Models;

namespace ProgressAcademy.Domain.Repositories;

/// <summary>
/// Defines the interface for lesson repository operations, encapsulating methods for managing lessons within the system.
/// </summary>
public interface ILessonRepository {
    /// <summary>
    /// Retrieves all lessons available in the system.
    /// </summary>
    /// <returns>A list of all lessons.</returns>
    Task<IEnumerable<Lesson>> GetAllLessonsAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a specific lesson by its unique identifier.
    /// </summary>
    /// <param name="lessonId">The unique identifier of the lesson to retrieve.</param>
    /// <returns>The lesson matching the provided identifier; null if not found.</returns>
    Task<Lesson> GetLessonByIdAsync(int lessonId, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new lesson and adds it to the system.
    /// </summary>
    /// <param name="lesson">The lesson to add to the system.</param>
    Task CreateLessonAsync(Lesson lesson, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing lesson in the system.
    /// </summary>
    /// <param name="lesson">The lesson with updated information.</param>
    Task UpdateLessonAsync(Lesson lesson, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a lesson from the system based on its unique identifier.
    /// </summary>
    /// <param name="lessonId">The unique identifier of the lesson to be deleted.</param>
    Task DeleteLessonAsync(int lessonId, CancellationToken cancellationToken);
}
