using ProgressAcademy.Domain.Models;

namespace ProgressAcademy.Domain.Repositories;

/// <summary>
/// Defines the interface for mentee repository operations, encapsulating methods for managing mentees within the system.
/// </summary>
public interface IMenteeRepository {
    /// <summary>
    /// Retrieves all mentees registered in the system.
    /// </summary>
    /// <returns>A list of all mentees.</returns>
    Task<IEnumerable<Mentee>> GetAllMenteesAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a specific mentee by their unique identifier.
    /// </summary>
    /// <param name="menteeId">The unique identifier of the mentee to retrieve.</param>
    /// <returns>The mentee matching the provided identifier; null if not found.</returns>
    Task<Mentee> GetMenteeByIdAsync(int menteeId, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new mentee and adds them to the system.
    /// </summary>
    /// <param name="mentee">The mentee to add to the system.</param>
    Task CreateMenteeAsync(Mentee mentee, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing mentee's information in the system.
    /// </summary>
    /// <param name="mentee">The mentee with updated information.</param>
    Task UpdateMenteeAsync(Mentee mentee, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a mentee from the system based on their unique identifier.
    /// </summary>
    /// <param name="menteeId">The unique identifier of the mentee to be deleted.</param>
    Task DeleteMenteeAsync(int menteeId, CancellationToken cancellationToken);
}
