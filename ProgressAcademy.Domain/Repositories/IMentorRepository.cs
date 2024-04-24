using ProgressAcademy.Domain.Models;

namespace ProgressAcademy.Domain.Repositories;

/// <summary>
/// Defines the interface for mentor repository operations, encapsulating methods for managing mentors within the system.
/// </summary>
public interface IMentorRepository {
    /// <summary>
    /// Retrieves all mentors registered in the system.
    /// </summary>
    /// <returns>A list of all mentors.</returns>
    Task<IEnumerable<Mentor>> GetAllMentorsAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a specific mentor by their unique identifier.
    /// </summary>
    /// <param name="mentorId">The unique identifier of the mentor to retrieve.</param>
    /// <returns>The mentor matching the provided identifier; null if not found.</returns>
    Task<Mentor> GetMentorByIdAsync(int mentorId, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new mentor and adds them to the system.
    /// </summary>
    /// <param name="mentor">The mentor to add to the system.</param>
    Task CreateMentorAsync(Mentor mentor, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing mentor's information in the system.
    /// </summary>
    /// <param name="mentor">The mentor with updated information.</param>
    Task UpdateMentorAsync(Mentor mentor, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a mentor from the system based on their unique identifier.
    /// </summary>
    /// <param name="mentorId">The unique identifier of the mentor to be deleted.</param>
    Task DeleteMentorAsync(int mentorId, CancellationToken cancellationToken);
}
